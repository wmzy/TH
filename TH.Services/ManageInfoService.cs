using System;
using System.Collections.Generic;
using System.Linq;
using TH.Model;
using TH.Repositories;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IManageInfoService : IService
    {
        IQueryable<InfoBase> Get(string infoType);
        IQueryable<InfoBase> GetByUserId(string infoType, string userId);
        InfoBase GetById(string infoType, int id);
    }

    public class ManageInfoService : IManageInfoService
    {
        private readonly THDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public ManageInfoService(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
        {
            _dbContext = databaseFactory.Get();
            _unitOfWork = unitOfWork;
        }

        public IQueryable<InfoBase> Get(string infoType)
        {
            switch (infoType)
            {
                case "Job":
                    return _dbContext.Jobs;
                case "JobHunting":
                    return _dbContext.JobHuntings;
                case "Project":
                    return _dbContext.Projects;
                case "ContractProject":
                    return _dbContext.ContractProjects;
                case "Machine":
                    return _dbContext.Machines;
                case "UseMachine":
                    return _dbContext.UseMachines;
                case "Equipment":
                    return _dbContext.Equipments;
                case "UseEquipment":
                    return _dbContext.UseEquipments;
                case "BuildingMaterial":
                    return _dbContext.BuildingMaterials;
                case "BuyBuildingMaterial":
                    return _dbContext.BuyBuildingMaterials;
                case "Detection":
                    return _dbContext.Detections;
                case "RequireDetection":
                    return _dbContext.RequireDetections;
                case "Credential":
                    return _dbContext.Credentials;
                case "RequireCredential":
                    return _dbContext.RequireCredentials;
                case "Financing":
                    return _dbContext.Financings;
                case "OtherInfo":
                    return _dbContext.OtherInfos;
                default:
                    throw new Exception("infoType错误！");
            }
        }

        public IQueryable<InfoBase> GetByUserId(string infoType, string userId)
        {
            return Get(infoType).Where(info => info.PublisherId == userId);
        }

        public InfoBase GetById(string infoType, int id)
        {
            return Get(infoType).FirstOrDefault(info => info.Id == id);
        }
    }
}