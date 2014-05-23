using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IMachineService : IService
    {
        IQueryable<Machine> Get(int pageIndex, int pageSize, out int recordCount);
        IEnumerable<Machine> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);
        IQueryable<Machine> GetByUserId(string userId);

        void Create(Machine machine);

        void Update(Machine machine);

        void OwnerDelete(string ownerId, int id);

        Machine GetById(int id);
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

        public IQueryable<Machine> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Machine> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Machine> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(Machine machine)
        {
            throw new NotImplementedException();
        }

        public void Update(Machine machine)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }


        public Machine GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}