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
    public interface IDetectionService : IService
    {
        IQueryable<Detection> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Detection> Get();
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

        public Detection GetById(int id)
        {
            return _detectionRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<Detection> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _detectionRepository.Count(m => true);
            return _detectionRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<Detection> Get()
        {
            return _detectionRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<Detection> GetByUserId(string userId)
        {
            return _detectionRepository.Get(j => j.Publisher.Id == userId);
        }

        public void Create(Detection detection)
        {
            _detectionRepository.Add(detection);
            _unitOfWork.Commit();
        }


        public void Update(Detection detection)
        {
            _detectionRepository.Update(detection);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var detection = GetById(id);

            if (detection != null && detection.PublisherId == ownerId)
            {
                _detectionRepository.Delete(detection);
                _unitOfWork.Commit();
            }
        }
    }
}
