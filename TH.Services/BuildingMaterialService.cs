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
    public interface IBuildingMaterialService : IService
    {
        IQueryable<BuildingMaterial> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<BuildingMaterial> Get();

        IQueryable<BuildingMaterial> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);    // 按工作地点分类

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

        public BuildingMaterial GetById(int id)
        {
            return _buildingMaterialRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<BuildingMaterial> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _buildingMaterialRepository.Count(m => true);
            return _buildingMaterialRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<BuildingMaterial> Get()
        {
            return _buildingMaterialRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<BuildingMaterial> GetByUserId(string userId)
        {
            return _buildingMaterialRepository.Get(j => j.Publisher.Id == userId);
        }

        public IEnumerable<BuildingMaterial> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _buildingMaterialRepository.Count(m => true);
            return _buildingMaterialRepository.Get(m => m.Location == location, pageIndex, pageSize, m => m.CreateDate);
        }


        public void Create(BuildingMaterial buildingMaterial)
        {
            _buildingMaterialRepository.Add(buildingMaterial);
            _unitOfWork.Commit();
        }


        public void Update(BuildingMaterial buildingMaterial)
        {
            _buildingMaterialRepository.Update(buildingMaterial);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var buildingMaterial = GetById(id);

            if (buildingMaterial != null && buildingMaterial.PublisherId == ownerId)
            {
                _buildingMaterialRepository.Delete(buildingMaterial);
                _unitOfWork.Commit();
            }
        }


        IQueryable<BuildingMaterial> IBuildingMaterialService.GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }
    }
}
