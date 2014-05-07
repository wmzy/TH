using System;
using System.Collections.Generic;
using System.Linq;
using TH.Repositories;
using TH.Repositories.Entities;
using TH.Repositories.Infrastructure;

namespace TH.Services
{
    public class JobService : IJobService
    {
        private readonly IRepository<Job> _jobRepository;
        private readonly IUnitOfWork _unitOfWork;
        public JobService(IRepository<Job> jobRepository, IUnitOfWork unitOfWork)
        {
            _jobRepository = jobRepository;
            _unitOfWork = unitOfWork;
        }

        public Job GetJobById(int id)
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
            var job = GetJobById(id);

            if (job.Publisher.Id == ownerId)
            {
                _jobRepository.Delete(job);
                _unitOfWork.Commit();
            }
        }
    }
}
