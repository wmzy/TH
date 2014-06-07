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
    public interface IRequireCredentialService : IService
    {
        IQueryable<RequireCredential> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<RequireCredential> Get();
        RequireCredential GetById(int id);
        IQueryable<RequireCredential> GetByUserId(string userId);

        void Create(RequireCredential requireCredential);

        void Update(RequireCredential requireCredential);

        void OwnerDelete(string ownerId, int id);
    }
    public class RequireCredentialService : IRequireCredentialService
    {
        private readonly IRequireCredentialRepository _requireCredentialRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RequireCredentialService(IRequireCredentialRepository requireCredentialRepository, IUnitOfWork unitOfWork)
        {
            _requireCredentialRepository = requireCredentialRepository;
            _unitOfWork = unitOfWork;
        }

        public RequireCredential GetById(int id)
        {
            return _requireCredentialRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<RequireCredential> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _requireCredentialRepository.Count(m => true);
            return _requireCredentialRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<RequireCredential> Get()
        {
            return _requireCredentialRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<RequireCredential> GetByUserId(string userId)
        {
            return _requireCredentialRepository.Get(j => j.Publisher.Id == userId);
        }

        public void Create(RequireCredential requireCredential)
        {
            _requireCredentialRepository.Add(requireCredential);
            _unitOfWork.Commit();
        }


        public void Update(RequireCredential requireCredential)
        {
            _requireCredentialRepository.Update(requireCredential);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var requireCredential = GetById(id);

            if (requireCredential != null && requireCredential.PublisherId == ownerId)
            {
                _requireCredentialRepository.Delete(requireCredential);
                _unitOfWork.Commit();
            }
        }
    }
}
