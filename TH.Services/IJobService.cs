using TH.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Services
{
    public interface IJobService
    {
        //IEnumerable<Job> GetJobsTypeId(int id, int pageIndex, int pageSize, out int recordCount);
        IEnumerable<Job> GetJobs(int id, int pageIndex, int pageSize, out int? recordCount);

        Job GetJobByLocation(int id, int pageIndex, int pageSize, out int recordCount);    // 按工作地点分类

        Job GetJobById(int id);
    }
}
