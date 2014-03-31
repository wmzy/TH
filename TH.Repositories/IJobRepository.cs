using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TH.Repositories.Entities;

namespace TH.Repositories
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetJobs(int pageIndex, int pageSize, out int recordCount);
        IEnumerable<Job> GetJobsByName(string name, int pageIndex, int pageSize, out int recordCount);
        //IEnumerable<Job> GetJobsByType(string type, int pageIndex, int pageSize, out int recordCount);
        //IEnumerable<Job> GetJobsByTypeId(int Id, int pageIndex, int pageSize, out int recordCount);
        //IEnumerable<Job> GetJobsByTag(string tag, int pageIndex, int pageSize, out int recordCount);
        Job GetJob(int jobId);
    }
}
