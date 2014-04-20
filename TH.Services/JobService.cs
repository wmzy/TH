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
        readonly IRepository<Job> _jobRepository;
        public JobService(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Job GetJobById(int id)
        {
            return _jobRepository.Get(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Job> GetJobByLocation(string location,int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _jobRepository.Count(m => true);
            return _jobRepository.Get(m => m.Location == location, pageIndex, pageSize, m => m.CreatedDate);
        }

        public IEnumerable<Job> GetJobs(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _jobRepository.Count(m => true);
            return _jobRepository.Get(m => true, pageIndex, pageSize, m => m.CreatedDate);
        }

        public void CreateJob(Job job)
        {
            _jobRepository.Add(job);
        }
    }
}
