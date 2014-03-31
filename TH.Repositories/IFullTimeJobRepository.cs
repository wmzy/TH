using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TH.Repositories.Entities;

namespace TH.Repositories
{
    public interface IFullTimeJobRepository
    {
        IEnumerable<FullTimeJob> GetFullTimeJobs(int pageIndex, int pageSize, out int recordCount);
        IEnumerable<FullTimeJob> GetFullTimeJobsByName(string name, int pageIndex, int pageSize, out int recordCount);
        IEnumerable<FullTimeJob> GetFullTimeJobsByTrade(string trade, int pageIndex, int pageSize, out int recordCount);
        IEnumerable<FullTimeJob> GetFullTimeJobsByType(string type, int pageIndex, int pageSize, out int recordCount);
        IEnumerable<FullTimeJob> GetFullTimeJobsByTypeId(int Id, int pageIndex, int pageSize, out int recordCount);
        IEnumerable<FullTimeJob> GetFullTimeJobsByTag(string tag, int pageIndex, int pageSize, out int recordCount);
        IEnumerable<FullTimeJobType> GetTypes();
        FullTimeJob GetFullTimeJob(int fullTimeJobId);
        void AddCompany(Company company);
    }
}
