using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IEquipmentService : IService
    {
        IQueryable<Equipment> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Equipment> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);
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

        public IQueryable<Equipment> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Equipment> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public Equipment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Equipment> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public void Update(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}