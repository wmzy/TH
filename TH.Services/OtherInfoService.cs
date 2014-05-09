using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IOtherInfoService : IService
    {
        IQueryable<OtherInfo> Get(int pageIndex, int pageSize, out int recordCount);
        OtherInfo GetById(int id);
        IQueryable<OtherInfo> GetByUserId(string userId);

        void Create(OtherInfo info);

        void Update(OtherInfo info);

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

        public IQueryable<OtherInfo> Get(int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public OtherInfo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OtherInfo> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(OtherInfo info)
        {
            throw new NotImplementedException();
        }

        public void Update(OtherInfo info)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}