using TH.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Services
{
    public interface IFullTimeJobService
    {
        IEnumerable<FullTimeJobType> GetTypes();

        IEnumerable<FullTimeJob> GetFullTimeJobsTypeId(int id, int pageIndex, int pageSize, out int recordCount);

        void AddCompany(Company company);
    }
}
