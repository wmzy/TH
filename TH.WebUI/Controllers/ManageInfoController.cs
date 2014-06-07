using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using TH.Model;
using TH.Services;
using TH.WebUI.ViewModels;

namespace TH.WebUI.Controllers
{
    [Authorize]
    public class ManageInfoController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IManageInfoService _manageInfoService;
        public ManageInfoController(IJobService jobService, IManageInfoService manageInfoService)
        {
            _jobService = jobService;
            _manageInfoService = manageInfoService;
        }

        //
        // GET: /ManageInfo/
        public ActionResult Index()
        {
            var model = new List<InfosViewModel>();
            var jobs = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("Job", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "招聘信息",
                ControllerName = "Job"
            };
            model.Add(jobs);
            var jobHuntings = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("JobHunting", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "求职信息",
                ControllerName = "JobHunting"
            };
            model.Add(jobHuntings);
            var projects = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("Project", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "工程招标、发包工程信息",
                ControllerName = "Project"
            };
            model.Add(projects);
            var contractProjects = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("ContractProject", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "承揽工程信息",
                ControllerName = "ContractProject"
            };
            model.Add(contractProjects);
            var machines = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("Machine", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "出租、出售工程机械信息",
                ControllerName = "Machine"
            };
            model.Add(machines);
            var usemachines = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("UseMachine", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "求租、求购工程机械信息",
                ControllerName = "UseMachine"
            };
            model.Add(usemachines);
            var equipments = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("Equipment", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "出租、出售工程设备及小型机具信息",
                ControllerName = "Equipment"
            };
            model.Add(equipments);
            var useequipments = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("UseEquipment", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "求租、求购工程设备及小型机具信息",
                ControllerName = "UseEquipment"
            };
            model.Add(useequipments);
            var buildingMaterials = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("BuildingMaterial", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "出售建筑材料信息",
                ControllerName = "BuildingMaterial"
            };
            model.Add(buildingMaterials);
            var buyBuildingMaterials = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("BuyBuildingMaterial", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "求购建筑材料信息",
                ControllerName = "BuyBuildingMaterial"
            };
            model.Add(buyBuildingMaterials);
            var detections = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("Detection", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "试验、检测信息",
                ControllerName = "Detection"
            };
            model.Add(detections);
            var requireDetections = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("RequireDetection", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "寻找试验、检测资质单位信息",
                ControllerName = "RequireDetection"
            };
            model.Add(requireDetections);
            var credentials = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("Credential", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "聘用证件持有人信息",
                ControllerName = "Credential"
            };
            model.Add(credentials);
            var requireCredentials = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("RequireCredential", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "证件注册、挂靠信息",
                ControllerName = "RequireCredential"
            };
            model.Add(requireCredentials);
            var financings = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("Financing", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "资金信息",
                ControllerName = "Financing"
            };
            model.Add(financings);
            var otherInfos = new InfosViewModel
            {
                Infos = _manageInfoService.GetByUserId("OtherInfo", User.Identity.GetUserId()).Project().To<InfoViewModel>(),
                Genre = "其它信息",
                ControllerName = "OtherInfo"
            };
            model.Add(otherInfos);

            //infoView.Add(othos);

            return View(model);
        }
    }
}
