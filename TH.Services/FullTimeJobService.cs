using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Repositories;
using TH.Repositories.Entities;

namespace TH.Services
{
    public class FullTimeJobService : ServiceBase, IFullTimeJobService, IDisposable
    {
        readonly IFullTimeJobRepository fullTimeJobRepository;
        public FullTimeJobService(IFullTimeJobRepository fullTimeJobRepository)
        {
            this.fullTimeJobRepository = fullTimeJobRepository;
        }
        public IEnumerable<FullTimeJobType> GetTypes()
        {
            return this.fullTimeJobRepository.GetTypes();
        }
        public IEnumerable<FullTimeJob> GetFullTimeJobsTypeId(int Id, int pageIndex, int pageSize, out int recordCount)
        {
            return fullTimeJobRepository.GetFullTimeJobsByTypeId(Id, pageIndex, pageSize, out recordCount);
        }

        public void AddCompany(Company company)
        {
            fullTimeJobRepository.AddCompany(company);
        }
    }
}
