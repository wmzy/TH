using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IUseMachineService : IService
    {
        IQueryable<UseMachine> Get(int pageIndex, int pageSize, out int recordCount);
        UseMachine GetById(int id);
        IQueryable<UseMachine> GetByUserId(string userId);

        void Create(UseMachine job);

        void Update(UseMachine job);

        void OwnerDelete(string ownerId, int id);
    }

    public class UseMachineService : IUseMachineService
    {
        private readonly IUseMachineRepository _machineRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UseMachineService(IUseMachineRepository machineRepository, IUnitOfWork unitOfWork)
        {
            _machineRepository = machineRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<UseMachine> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public UseMachine GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UseMachine> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(UseMachine job)
        {
            throw new NotImplementedException();
        }

        public void Update(UseMachine job)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}