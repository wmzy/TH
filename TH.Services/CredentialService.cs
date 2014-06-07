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
    public interface ICredentialService : IService
    {
        IQueryable<Credential> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Credential> Get();
        Credential GetById(int id);
        IQueryable<Credential> GetByUserId(string userId);

        void Create(Credential credential);

        void Update(Credential credential);

        void OwnerDelete(string ownerId, int id);
    }
    public class CredentialService : ICredentialService
    {
        private readonly ICredentialRepository _credentialRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CredentialService(ICredentialRepository credentialRepository, IUnitOfWork unitOfWork)
        {
            _credentialRepository = credentialRepository;
            _unitOfWork = unitOfWork;
        }

        public Credential GetById(int id)
        {
            return _credentialRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<Credential> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _credentialRepository.Count(m => true);
            return _credentialRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<Credential> Get()
        {
            return _credentialRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<Credential> GetByUserId(string userId)
        {
            return _credentialRepository.Get(j => j.Publisher.Id == userId);
        }

        public void Create(Credential credential)
        {
            _credentialRepository.Add(credential);
            _unitOfWork.Commit();
        }


        public void Update(Credential credential)
        {
            _credentialRepository.Update(credential);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var credential = GetById(id);

            if (credential != null && credential.PublisherId == ownerId)
            {
                _credentialRepository.Delete(credential);
                _unitOfWork.Commit();
            }
        }
    }
}
