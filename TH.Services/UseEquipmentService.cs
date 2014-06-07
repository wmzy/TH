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
    public interface IUseEquipmentService : IService
    {
        IQueryable<UseEquipment> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<UseEquipment> Get();

        IQueryable<UseEquipment> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);    // 按工作地点分类

        UseEquipment GetById(int id);
        IQueryable<UseEquipment> GetByUserId(string userId);

        void Create(UseEquipment useEquipment);

        void Update(UseEquipment useEquipment);

        void OwnerDelete(string ownerId, int id);
    }
    public class UseEquipmentService : IUseEquipmentService
    {
        private readonly IUseEquipmentRepository _useEquipmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UseEquipmentService(IUseEquipmentRepository useEquipmentRepository, IUnitOfWork unitOfWork)
        {
            _useEquipmentRepository = useEquipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public UseEquipment GetById(int id)
        {
            return _useEquipmentRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<UseEquipment> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _useEquipmentRepository.Count(m => true);
            return _useEquipmentRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<UseEquipment> Get()
        {
            return _useEquipmentRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<UseEquipment> GetByUserId(string userId)
        {
            return _useEquipmentRepository.Get(j => j.Publisher.Id == userId);
        }

        public IEnumerable<UseEquipment> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _useEquipmentRepository.Count(m => true);
            return _useEquipmentRepository.Get(m => m.Location == location, pageIndex, pageSize, m => m.CreateDate);
        }


        public void Create(UseEquipment useEquipment)
        {
            _useEquipmentRepository.Add(useEquipment);
            _unitOfWork.Commit();
        }


        public void Update(UseEquipment useEquipment)
        {
            _useEquipmentRepository.Update(useEquipment);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var useEquipment = GetById(id);

            if (useEquipment != null && useEquipment.PublisherId == ownerId)
            {
                _useEquipmentRepository.Delete(useEquipment);
                _unitOfWork.Commit();
            }
        }


        IQueryable<UseEquipment> IUseEquipmentService.GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }
    }
}
