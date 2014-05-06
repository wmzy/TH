using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Repositories;
using TH.Repositories.Entities;

namespace TH.Services
{
    public class JobHuntingService : IJobHuntingService
    {
        private readonly IRepository<JobHunting> _jobHuntingRepository;
        public JobHuntingService(IRepository<JobHunting> jobHuntingRepository)
        {
            _jobHuntingRepository = jobHuntingRepository;
        }

        public IQueryable<JobHunting> GetJobHuntings(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _jobHuntingRepository.Count(m => true);
            return _jobHuntingRepository.Get(m => true, pageIndex, pageSize, m => m.CreatedDate);
        }


        public void CreateJobHunting(JobHunting job)
        {
            _jobHuntingRepository.Add(job);
        }

        public JobHunting GetJobHuntingById(int id)
        {
            return _jobHuntingRepository.Get(m => m.Id == id).FirstOrDefault();
        }

        public void Update(JobHunting jobHunting)
        {
            _jobHuntingRepository.Update(jobHunting);
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var jobHunting = GetJobHuntingById(id);

            if (jobHunting.Publisher.Id == ownerId)
            {
                _jobHuntingRepository.Delete(jobHunting);
            }
        }
    }
}
