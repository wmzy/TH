using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Services;
using TH.WebUI.ViewModels;

namespace TH.WebUI.Controllers
{
    [Authorize]
    public class ContractProjectController : Controller
    {
        private readonly IContractProjectService _contractProjectService;
        public ContractProjectController(IContractProjectService contractProjectService)
        {
            _contractProjectService = contractProjectService;
        }

        //
        // GET: /ContractProject/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContractProjectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ContractProject contractProject = Mapper.Map<ContractProjectCreateViewModel, ContractProject>(model);
                contractProject.City = ControllerContext.HttpContext.Request.UserHostAddress;
                contractProject.PublisherId = User.Identity.GetUserId();

                _contractProjectService.Create(contractProject);

                return RedirectToAction("Details", new {id = contractProject.Id});
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var contractProject = _contractProjectService.GetById(id);
            var model = Mapper.Map<ContractProject, ContractProjectDetailsViewModel>(contractProject);
            return View(model);
        }
	}
}