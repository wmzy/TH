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
    public interface IEquipmentService : IService
    {
        IQueryable<Equipment> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Equipment> Get();

        IQueryable<Equipment> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);    // 按工作地点分类

        Equipment GetById(int id);
        IQueryable<Equipment> GetByUserId(string userId);

        void Create(Equipment equipment);

        void Update(Equipment equipment);

        void OwnerDelete(string ownerId, int id);
    }
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EquipmentService(IEquipmentRepository equipmentRepository, IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Equipment GetById(int id)
        {
            return _equipmentRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<Equipment> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _equipmentRepository.Count(m => true);
            return _equipmentRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<Equipment> Get()
        {
            return _equipmentRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<Equipment> GetByUserId(string userId)
        {
            return _equipmentRepository.Get(j => j.Publisher.Id == userId);
        }

        public IEnumerable<Equipment> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _equipmentRepository.Count(m => true);
            return _equipmentRepository.Get(m => m.Location == location, pageIndex, pageSize, m => m.CreateDate);
        }


        public void Create(Equipment equipment)
        {
            _equipmentRepository.Add(equipment);
            _unitOfWork.Commit();
        }


        public void Update(Equipment equipment)
        {
            _equipmentRepository.Update(equipment);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var equipment = GetById(id);

            if (equipment != null && equipment.PublisherId == ownerId)
            {
                _equipmentRepository.Delete(equipment);
                _unitOfWork.Commit();
            }
        }


        IQueryable<Equipment> IEquipmentService.GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }
    }
}
