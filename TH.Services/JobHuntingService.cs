using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Repositories;
using TH.Repositories.Entities;
using TH.Repositories.Infrastructure;

namespace TH.Services
{
    public class JobHuntingService : IJobHuntingService
    {
        private readonly IRepository<JobHunting> _jobHuntingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public JobHuntingService(IRepository<JobHunting> jobHuntingRepository, IUnitOfWork unitOfWork)
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
