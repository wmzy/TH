using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IBuyBuildingMaterialService : IService
    {
        IQueryable<BuyBuildingMaterial> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<BuyBuildingMaterial> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);
        BuyBuildingMaterial GetById(int id);
        IQueryable<BuyBuildingMaterial> GetByUserId(string userId);

        void Create(BuyBuildingMaterial buyBuildingMaterial);

        void Update(BuyBuildingMaterial buyBuildingMaterial);

        void OwnerDelete(string ownerId, int id);
    }

    public class BuyBuildingMaterialService : IBuyBuildingMaterialService
    {
        private readonly IBuyBuildingMaterialRepository _buyBuildingMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BuyBuildingMaterialService(IBuyBuildingMaterialRepository buyBuildingMaterialRepository, IUnitOfWork unitOfWork)
        {
            _buyBuildingMaterialRepository = buyBuildingMaterialRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<BuyBuildingMaterial> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BuyBuildingMaterial> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public BuyBuildingMaterial GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BuyBuildingMaterial> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(BuyBuildingMaterial buyBuildingMaterial)
        {
            throw new NotImplementedException();
        }

        public void Update(BuyBuildingMaterial buyBuildingMaterial)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}