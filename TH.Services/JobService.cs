using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IJobService : IService
    {
        IQueryable<Job> Get(int pageIndex, int pageSize, out int recordCount);

        IQueryable<Job> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);    // 按工作地点分类

        Job GetById(int id);
        IQueryable<Job> GetByUserId(string userId);

        void Create(Job job);

        void Update(Job job);

        void OwnerDelete(string ownerId, int id);
    }
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUnitOfWork _unitOfWork;
        public JobService(IJobRepository jobRepository, IUnitOfWork unitOfWork)
        {
            _jobRepository = jobRepository;
            _unitOfWork = unitOfWork;
        }

        public Job GetById(int id)
        {
            return _jobRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<Job> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _jobRepository.Count(m => true);
            return _jobRepository.Get(m => true, pageIndex, pageSize, m => m.CreatedDate);
        }

        public IQueryable<Job> GetByUserId(string userId)
        {
            return _jobRepository.Get(j => j.Publisher.Id == userId);
        }

        public IEnumerable<Job> GetByLocation(string location,int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _jobRepository.Count(m => true);
            return _jobRepository.Get(m => m.Location == location, pageIndex, pageSize, m => m.CreatedDate);
        }


        public void Create(Job job)
        {
            _jobRepository.Add(job);
            _unitOfWork.Commit();
        }


        public void Update(Job job)
        {
            _jobRepository.Update(job);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var job = GetById(id);

            if (job.Publisher.Id == ownerId)
            {
                _jobRepository.Delete(job);
                _unitOfWork.Commit();
            }
        }
    }
}
