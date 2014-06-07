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
    public interface IUseMachineService : IService
    {
        IQueryable<UseMachine> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<UseMachine> Get();

        IQueryable<UseMachine> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);    // 按工作地点分类

        UseMachine GetById(int id);
        IQueryable<UseMachine> GetByUserId(string userId);

        void Create(UseMachine useMachine);

        void Update(UseMachine useMachine);

        void OwnerDelete(string ownerId, int id);
    }
    public class UseMachineService : IUseMachineService
    {
        private readonly IUseMachineRepository _useMachineRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UseMachineService(IUseMachineRepository useMachineRepository, IUnitOfWork unitOfWork)
        {
            _useMachineRepository = useMachineRepository;
            _unitOfWork = unitOfWork;
        }

        public UseMachine GetById(int id)
        {
            return _useMachineRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<UseMachine> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _useMachineRepository.Count(m => true);
            return _useMachineRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<UseMachine> Get()
        {
            return _useMachineRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<UseMachine> GetByUserId(string userId)
        {
            return _useMachineRepository.Get(j => j.Publisher.Id == userId);
        }

        public IEnumerable<UseMachine> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _useMachineRepository.Count(m => true);
            return _useMachineRepository.Get(m => m.Location == location, pageIndex, pageSize, m => m.CreateDate);
        }


        public void Create(UseMachine useMachine)
        {
            _useMachineRepository.Add(useMachine);
            _unitOfWork.Commit();
        }


        public void Update(UseMachine useMachine)
        {
            _useMachineRepository.Update(useMachine);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var useMachine = GetById(id);

            if (useMachine != null && useMachine.PublisherId == ownerId)
            {
                _useMachineRepository.Delete(useMachine);
                _unitOfWork.Commit();
            }
        }


        IQueryable<UseMachine> IUseMachineService.GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }
    }
}
