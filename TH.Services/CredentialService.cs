using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface ICredentialService : IService
    {
        IQueryable<Credential> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Credential> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);
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

        public IQueryable<Credential> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Credential> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public Credential GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Credential> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(Credential credential)
        {
            throw new NotImplementedException();
        }

        public void Update(Credential credential)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}