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
    public interface IFinancingService : IService
    {
        IQueryable<Financing> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Financing> Get();
        Financing GetById(int id);
        IQueryable<Financing> GetByUserId(string userId);

        void Create(Financing financing);

        void Update(Financing financing);

        void OwnerDelete(string ownerId, int id);
    }
    public class FinancingService : IFinancingService
    {
        private readonly IFinancingRepository _financingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FinancingService(IFinancingRepository financingRepository, IUnitOfWork unitOfWork)
        {
            _financingRepository = financingRepository;
            _unitOfWork = unitOfWork;
        }

        public Financing GetById(int id)
        {
            return _financingRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<Financing> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _financingRepository.Count(m => true);
            return _financingRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<Financing> Get()
        {
            return _financingRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<Financing> GetByUserId(string userId)
        {
            return _financingRepository.Get(j => j.Publisher.Id == userId);
        }
        public void Create(Financing financing)
        {
            _financingRepository.Add(financing);
            _unitOfWork.Commit();
        }


        public void Update(Financing financing)
        {
            _financingRepository.Update(financing);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var financing = GetById(id);

            if (financing != null && financing.PublisherId == ownerId)
            {
                _financingRepository.Delete(financing);
                _unitOfWork.Commit();
            }
        }
    }
}
