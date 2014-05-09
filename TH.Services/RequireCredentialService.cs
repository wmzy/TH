using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IRequireCredentialService : IService
    {
        IQueryable<RequireCredential> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<RequireCredential> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);
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

        public IQueryable<RequireCredential> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RequireCredential> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public RequireCredential GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RequireCredential> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(RequireCredential requireCredential)
        {
            throw new NotImplementedException();
        }

        public void Update(RequireCredential requireCredential)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}