using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IRequireDetectionService : IService
    {
        IQueryable<RequireDetection> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<RequireDetection> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);
        RequireDetection GetById(int id);
        IQueryable<RequireDetection> GetByUserId(string userId);

        void Create(RequireDetection requireDetection);

        void Update(RequireDetection requireDetection);

        void OwnerDelete(string ownerId, int id);
    }

    public class RequireDetectionService : IRequireDetectionService
    {
        private readonly IRequireDetectionRepository _requireDetectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RequireDetectionService(IRequireDetectionRepository requireDetectionRepository, IUnitOfWork unitOfWork)
        {
            _requireDetectionRepository = requireDetectionRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<RequireDetection> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RequireDetection> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public RequireDetection GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RequireDetection> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(RequireDetection requireDetection)
        {
            throw new NotImplementedException();
        }

        public void Update(RequireDetection requireDetection)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}