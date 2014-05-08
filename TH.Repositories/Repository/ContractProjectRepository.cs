using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class ContractProjectRepository : RepositoryBase<ContractProject>, IContractProjectRepository
    {
        public ContractProjectRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IContractProjectRepository : IRepository<ContractProject>
    {
    }
}
