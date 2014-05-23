using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<ContractProjectIndexViewModel> contractProjects = _contractProjectService.Get(pageIndex, pageSize, out recordCount).Project().To<ContractProjectIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(contractProjects);
        }

        //
        // GET: /ContractProject/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var contractProject = _contractProjectService.GetById(id);
            var model = Mapper.Map<ContractProject, ContractProjectDetailsViewModel>(contractProject);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContractProjectCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            ContractProject contractProject = Mapper.Map<ContractProjectCreateViewModel, ContractProject>(model);
            contractProject.City = ControllerContext.HttpContext.Request.UserHostAddress;
            contractProject.PublisherId = User.Identity.GetUserId();

            _contractProjectService.Create(contractProject);

            return RedirectToAction("Details", new {id = contractProject.Id});
        }
        public ActionResult Edit(int id)
        {
            ContractProject contractProject = _contractProjectService.GetById(id);
            if (contractProject.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var jobEdit = Mapper.Map<ContractProject, ContractProjectEditViewModel>(contractProject);

            return View(jobEdit);
        }

        [HttpPost]
        public ActionResult Edit(ContractProjectEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ContractProject contractProject = _contractProjectService.GetById(model.Id);

            if (contractProject.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, contractProject);

            _contractProjectService.Update(contractProject);

            return RedirectToAction("Details", new { id = contractProject.Id });
        }

        public ActionResult Delete(int id)
        {
            _contractProjectService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
	}
}