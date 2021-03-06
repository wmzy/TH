﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TH.Model;
using TH.Repositories;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IJobHuntingService : IService
    {
        IQueryable<JobHunting> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<JobHunting> Get();
        JobHunting GetById(int id);
        IQueryable<JobHunting> GetByUserId(string userId);

        void Create(JobHunting jobHunting);

        void Update(JobHunting jobHunting);

        void OwnerDelete(string ownerId, int id);
    }
    public class JobHuntingService : IJobHuntingService
    {
        private readonly IJobHuntingRepository _jobHuntingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public JobHuntingService(IJobHuntingRepository jobHuntingRepository, IUnitOfWork unitOfWork)
        {
            _jobHuntingRepository = jobHuntingRepository;
            _unitOfWork = unitOfWork;
        }

        public JobHunting GetById(int id)
        {
            return _jobHuntingRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<JobHunting> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _jobHuntingRepository.Count(m => true);
            return _jobHuntingRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<JobHunting> Get()
        {
            return _jobHuntingRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<JobHunting> GetByUserId(string userId)
        {
            return _jobHuntingRepository.Get(j => j.Publisher.Id == userId);
        }

        public void Create(JobHunting jobHunting)
        {
            _jobHuntingRepository.Add(jobHunting);
            _unitOfWork.Commit();
        }


        public void Update(JobHunting jobHunting)
        {
            _jobHuntingRepository.Update(jobHunting);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var jobHunting = GetById(id);

            if (jobHunting != null && jobHunting.PublisherId == ownerId)
            {
                _jobHuntingRepository.Delete(jobHunting);
                _unitOfWork.Commit();
            }
        }
    }
}
