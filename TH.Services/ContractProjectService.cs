using TH.Model;
using TH.Repositories;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public class ContractProjectService : IContractProjectRepository
    {
        private readonly IContractProjectRepository _contractProjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ContractProjectService(IContractProjectRepository contractProjectRepository, IUnitOfWork unitOfWork)
        {
            _contractProjectRepository = contractProjectRepository;
            _unitOfWork = unitOfWork;
        }

        public System.Linq.IQueryable<ContractProject> Get()
        {
            throw new System.NotImplementedException();
        }

        public System.Linq.IQueryable<ContractProject> Get(System.Linq.Expressions.Expression<System.Func<ContractProject, bool>> filter)
        {
            throw new System.NotImplementedException();
        }

        public System.Linq.IQueryable<ContractProject> Get<TOderKey>(System.Linq.Expressions.Expression<System.Func<ContractProject, bool>> filter, int pageIndex, int pageSize, System.Linq.Expressions.Expression<System.Func<ContractProject, TOderKey>> sortKeySelector, bool isAsc = true)
        {
            throw new System.NotImplementedException();
        }

        public int Count(System.Linq.Expressions.Expression<System.Func<ContractProject, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ContractProject instance)
        {
            throw new System.NotImplementedException();
        }

        public void Add(ContractProject instance)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(ContractProject instance)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(System.Linq.Expressions.Expression<System.Func<ContractProject, bool>> where)
        {
            throw new System.NotImplementedException();
        }
    }
}