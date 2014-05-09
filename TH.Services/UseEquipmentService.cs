using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IUseEquipmentService : IService
    {
        IQueryable<UseEquipment> Get(int pageIndex, int pageSize, out int recordCount);
        UseEquipment GetJobById(int id);
        IQueryable<UseEquipment> GetByUserId(string userId);

        void Create(UseEquipment job);

        void Update(UseEquipment job);

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

        public IQueryable<UseEquipment> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public UseEquipment GetJobById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UseEquipment> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(UseEquipment job)
        {
            throw new NotImplementedException();
        }

        public void Update(UseEquipment job)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}