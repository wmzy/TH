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
    public interface IRequireDetectionService : IService
    {
        IQueryable<RequireDetection> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<RequireDetection> Get();

        IQueryable<RequireDetection> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);    // 按工作地点分类

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

        public RequireDetection GetById(int id)
        {
            return _requireDetectionRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<RequireDetection> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _requireDetectionRepository.Count(m => true);
            return _requireDetectionRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<RequireDetection> Get()
        {
            return _requireDetectionRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<RequireDetection> GetByUserId(string userId)
        {
            return _requireDetectionRepository.Get(j => j.Publisher.Id == userId);
        }

        public IEnumerable<RequireDetection> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _requireDetectionRepository.Count(m => true);
            return _requireDetectionRepository.Get(m => m.Location == location, pageIndex, pageSize, m => m.CreateDate);
        }


        public void Create(RequireDetection requireDetection)
        {
            _requireDetectionRepository.Add(requireDetection);
            _unitOfWork.Commit();
        }


        public void Update(RequireDetection requireDetection)
        {
            _requireDetectionRepository.Update(requireDetection);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var requireDetection = GetById(id);

            if (requireDetection != null && requireDetection.PublisherId == ownerId)
            {
                _requireDetectionRepository.Delete(requireDetection);
                _unitOfWork.Commit();
            }
        }


        IQueryable<RequireDetection> IRequireDetectionService.GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }
    }
}
