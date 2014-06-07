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
    public interface IBuyBuildingMaterialService : IService
    {
        IQueryable<BuyBuildingMaterial> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<BuyBuildingMaterial> Get();

        IQueryable<BuyBuildingMaterial> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);    // 按工作地点分类

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

        public BuyBuildingMaterial GetById(int id)
        {
            return _buyBuildingMaterialRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<BuyBuildingMaterial> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _buyBuildingMaterialRepository.Count(m => true);
            return _buyBuildingMaterialRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<BuyBuildingMaterial> Get()
        {
            return _buyBuildingMaterialRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<BuyBuildingMaterial> GetByUserId(string userId)
        {
            return _buyBuildingMaterialRepository.Get(j => j.Publisher.Id == userId);
        }

        public IEnumerable<BuyBuildingMaterial> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _buyBuildingMaterialRepository.Count(m => true);
            return _buyBuildingMaterialRepository.Get(m => m.Location == location, pageIndex, pageSize, m => m.CreateDate);
        }


        public void Create(BuyBuildingMaterial buyBuildingMaterial)
        {
            _buyBuildingMaterialRepository.Add(buyBuildingMaterial);
            _unitOfWork.Commit();
        }


        public void Update(BuyBuildingMaterial buyBuildingMaterial)
        {
            _buyBuildingMaterialRepository.Update(buyBuildingMaterial);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var buyBuildingMaterial = GetById(id);

            if (buyBuildingMaterial != null && buyBuildingMaterial.PublisherId == ownerId)
            {
                _buyBuildingMaterialRepository.Delete(buyBuildingMaterial);
                _unitOfWork.Commit();
            }
        }


        IQueryable<BuyBuildingMaterial> IBuyBuildingMaterialService.GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }
    }
}
