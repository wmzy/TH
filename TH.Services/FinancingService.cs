using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IFinancingService : IService
    {
        IQueryable<Financing> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Financing> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);
        Financing GetById(int id);
        IQueryable<Financing> GetByUserId(string userId);

        void Create(Financing financing);

        void Update(Financing financing);

        void OwnerDelete(string ownerId, int id);
    }

    public class FinancingService : IFinancingService
    {
        private readonly IFinancingRepository _financingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FinancingService(IFinancingRepository financingRepository, IUnitOfWork unitOfWork)
        {
            _financingRepository = financingRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Financing> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Financing> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public Financing GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Financing> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(Financing financing)
        {
            throw new NotImplementedException();
        }

        public void Update(Financing financing)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}