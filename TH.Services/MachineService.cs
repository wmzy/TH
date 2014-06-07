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
    public interface IMachineService : IService
    {
        IQueryable<Machine> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Machine> Get();

        IQueryable<Machine> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);    // 按工作地点分类

        Machine GetById(int id);
        IQueryable<Machine> GetByUserId(string userId);

        void Create(Machine machine);

        void Update(Machine machine);

        void OwnerDelete(string ownerId, int id);
    }
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MachineService(IMachineRepository machineRepository, IUnitOfWork unitOfWork)
        {
            _machineRepository = machineRepository;
            _unitOfWork = unitOfWork;
        }

        public Machine GetById(int id)
        {
            return _machineRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<Machine> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _machineRepository.Count(m => true);
            return _machineRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<Machine> Get()
        {
            return _machineRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<Machine> GetByUserId(string userId)
        {
            return _machineRepository.Get(j => j.Publisher.Id == userId);
        }

        public IEnumerable<Machine> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _machineRepository.Count(m => true);
            return _machineRepository.Get(m => m.Location == location, pageIndex, pageSize, m => m.CreateDate);
        }


        public void Create(Machine machine)
        {
            _machineRepository.Add(machine);
            _unitOfWork.Commit();
        }


        public void Update(Machine machine)
        {
            _machineRepository.Update(machine);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var machine = GetById(id);

            if (machine != null && machine.PublisherId == ownerId)
            {
                _machineRepository.Delete(machine);
                _unitOfWork.Commit();
            }
        }


        IQueryable<Machine> IMachineService.GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }
    }
}
