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

            //infoView.Add(othos);

            return View(model);
        }
    }
}
