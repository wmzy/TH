using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;
using TH.Repositories;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IJobHuntingService : IService
    {
        IQueryable<JobHunting> Get(int pageIndex, int pageSize, out int recordCount);

        void Create(JobHunting job);

        JobHunting GetById(int id);

        void Update(JobHunting jobHunting);

        void OwnerDelete(string ownerId, int id);
    }
    public class JobHuntingService : IJobHuntingService
    {
        private readonly IJobHuntingRepository _jobHuntingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public JobHuntingService(IJobHuntingRepository jobHuntingRepository, IUnitOfWork unitOfWork)
        {
            _jobHuntingRepository = jobHuntingRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<JobHunting> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _jobHuntingRepository.Count(m => true);
            return _jobHuntingRepository.Get(m => true, pageIndex, pageSize, m => m.CreatedDate);
        }


        public void Create(JobHunting job)
        {
            _jobHuntingRepository.Add(job);
            _unitOfWork.Commit();
        }

        public JobHunting GetById(int id)
        {
            return _jobHuntingRepository.Get(m => m.Id == id).FirstOrDefault();
        }

        public void Update(JobHunting jobHunting)
        {
            _jobHuntingRepository.Update(jobHunting);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var jobHunting = GetById(id);

            if (jobHunting.Publisher.Id != ownerId) return;

            _jobHuntingRepository.Delete(jobHunting);
            _unitOfWork.Commit();
        }
    }
}
