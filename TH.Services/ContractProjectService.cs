using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TH.Model;
using TH.Repositories;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IContractProjectService : IService
    {
        IQueryable<ContractProject> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<ContractProject> Get();
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

        public ContractProject GetById(int id)
        {
            return _contractProjectRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<ContractProject> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _contractProjectRepository.Count(m => true);
            return _contractProjectRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<ContractProject> Get()
        {
            return _contractProjectRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<ContractProject> GetByUserId(string userId)
        {
            return _contractProjectRepository.Get(j => j.Publisher.Id == userId);
        }

        public void Create(ContractProject contractProject)
        {
            _contractProjectRepository.Add(contractProject);
            _unitOfWork.Commit();
        }


        public void Update(ContractProject contractProject)
        {
            _contractProjectRepository.Update(contractProject);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var contractProject = GetById(id);

            if (contractProject != null && contractProject.PublisherId == ownerId)
            {
                _contractProjectRepository.Delete(contractProject);
                _unitOfWork.Commit();
            }
        }
    }
}
