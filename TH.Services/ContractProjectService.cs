using TH.Repositories;
using TH.Repositories.Entities;
using TH.Repositories.Infrastructure;

namespace TH.Services
{
    public class ContractProjectService
    {
        private readonly IRepository<ContractProject> _contractProjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ContractProjectService(IRepository<ContractProject> contractProjectRepository, IUnitOfWork unitOfWork)
        {
            _contractProjectRepository = contractProjectRepository;
            _unitOfWork = unitOfWork;
        }
    }
}