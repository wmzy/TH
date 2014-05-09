using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IDetectionService : IService
    {
        IQueryable<Detection> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Detection> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);
        Detection GetById(int id);
        IQueryable<Detection> GetByUserId(string userId);

        void Create(Detection detection);

        void Update(Detection detection);

        void OwnerDelete(string ownerId, int id);
    }

    public class DetectionService : IDetectionService
    {
        private readonly IDetectionRepository _detectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DetectionService(IDetectionRepository detectionRepository, IUnitOfWork unitOfWork)
        {
            _detectionRepository = detectionRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Detection> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Detection> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public Detection GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Detection> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(Detection detection)
        {
            throw new NotImplementedException();
        }

        public void Update(Detection detection)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}