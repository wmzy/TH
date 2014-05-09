using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IBuildingMaterialService : IService
    {
        IQueryable<BuildingMaterial> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<BuildingMaterial> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);
        BuildingMaterial GetById(int id);
        IQueryable<BuildingMaterial> GetByUserId(string userId);

        void Create(BuildingMaterial buildingMaterial);

        void Update(BuildingMaterial buildingMaterial);

        void OwnerDelete(string ownerId, int id);
    }

    public class BuildingMaterialService : IBuildingMaterialService
    {
        private readonly IBuildingMaterialRepository _buildingMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BuildingMaterialService(IBuildingMaterialRepository buildingMaterialRepository, IUnitOfWork unitOfWork)
        {
            _buildingMaterialRepository = buildingMaterialRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<BuildingMaterial> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BuildingMaterial> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public BuildingMaterial GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BuildingMaterial> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(BuildingMaterial buildingMaterial)
        {
            throw new NotImplementedException();
        }

        public void Update(BuildingMaterial buildingMaterial)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}