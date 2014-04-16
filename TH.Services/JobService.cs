using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Repositories;
using TH.Repositories.Entities;

namespace TH.Services
{
    public class JobService : ServiceBase, IJobService, IDisposable
    {
        readonly IJobRepository jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public Job GetJobById(int id)
        {
            return jobRepository.GetJob(id);
        }

        public IEnumerable<Job> GetJobByLocation(int pageIndex, int pageSize, out int recordCount)
        {
            return jobRepository.GetJobs(pageIndex, pageSize, out recordCount);
        }

        public IEnumerable<Job> GetJobs(int pageIndex, int pageSize, out int recordCount)
        {
            return jobRepository.GetJobs(pageIndex, pageSize, out recordCount);
        }

        public void CreateJob(Job job)
        {

        }
    }
}
