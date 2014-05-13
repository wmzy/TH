using System.Linq;
using System.Linq.Expressions;
using TH.Model;
using TH.Repositories;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IContractProjectService : IService
    {
        IQueryable<ContractProject> Get(int pageIndex, int pageSize, out int recordCount);
        ContractProject GetById(int id);
        IQueryable<ContractProject> GetByUserId(string userId);
        void Create(ContractProject contractProject);
        void Update(ContractProject contractProject);
        void OwnerDelete(string ownerId, int id);
    }

    public class ContractProjectService : IContractProjectService
    {
        private readonly IContractProjectRepository _contractProjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ContractProjectService(IContractProjectRepository contractProjectRepository, IUnitOfWork unitOfWork)
        {
            _contractProjectRepository = contractProjectRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<ContractProject> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new System.NotImplementedException();
        }

        public ContractProject GetById(int id)
        {
            return _contractProjectRepository.Get(cp => cp.Id == id).FirstOrDefault();
        }

        public IQueryable<ContractProject> GetByUserId(string userId)
        {
            throw new System.NotImplementedException();
        }

        public void Create(ContractProject contractProject)
        {
            _contractProjectRepository.Add(contractProject);
            _unitOfWork.Commit();
        }

        public void Update(ContractProject contractProject)
        {
            throw new System.NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
        }
    }
}