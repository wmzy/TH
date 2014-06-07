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
    public interface IOtherInfoService : IService
    {
        IQueryable<OtherInfo> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<OtherInfo> Get();
        OtherInfo GetById(int id);
        IQueryable<OtherInfo> GetByUserId(string userId);

        void Create(OtherInfo otherInfo);

        void Update(OtherInfo otherInfo);

        void OwnerDelete(string ownerId, int id);
    }
    public class OtherInfoService : IOtherInfoService
    {
        private readonly IOtherInfoRepository _otherInfoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OtherInfoService(IOtherInfoRepository otherInfoRepository, IUnitOfWork unitOfWork)
        {
            _otherInfoRepository = otherInfoRepository;
            _unitOfWork = unitOfWork;
        }

        public OtherInfo GetById(int id)
        {
            return _otherInfoRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<OtherInfo> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _otherInfoRepository.Count(m => true);
            return _otherInfoRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<OtherInfo> Get()
        {
            return _otherInfoRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<OtherInfo> GetByUserId(string userId)
        {
            return _otherInfoRepository.Get(j => j.Publisher.Id == userId);
        }

        public void Create(OtherInfo otherInfo)
        {
            _otherInfoRepository.Add(otherInfo);
            _unitOfWork.Commit();
        }


        public void Update(OtherInfo otherInfo)
        {
            _otherInfoRepository.Update(otherInfo);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var otherInfo = GetById(id);

            if (otherInfo != null && otherInfo.PublisherId == ownerId)
            {
                _otherInfoRepository.Delete(otherInfo);
                _unitOfWork.Commit();
            }
        }
    }
}
