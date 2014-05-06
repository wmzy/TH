using TH.Repositories;
using TH.Repositories.Entities;

namespace TH.Services
{
    public class ContractProjectService
    {
        private readonly IRepository<ContractProject> _contractProjectRepository;
        public ContractProjectService(IRepository<ContractProject> contractProjectRepository)
        {
            _contractProjectRepository = contractProjectRepository;
        }
    }
}