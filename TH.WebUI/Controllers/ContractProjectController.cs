using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PagedList;
using TH.Model;
using TH.Services;
using TH.WebUI.ViewModels;
using Microsoft.AspNet.Identity;

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
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var contractProjectsPage = _contractProjectService.Get()
                .Project().To<ContractProjectIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(contractProjectsPage);
        }

        //
        // GET: /ContractProject/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            ContractProject contractProject = _contractProjectService.GetById(id);
            var contractProjectDetails = Mapper.Map<ContractProject, ContractProjectDetailsViewModel>(contractProject);

            return View(contractProjectDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContractProjectCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var contractProject = Mapper.Map<ContractProjectCreateViewModel, ContractProject>(model);

            contractProject.PublisherId = User.Identity.GetUserId();
            contractProject.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _contractProjectService.Create(contractProject);

            return RedirectToAction("Settlement", new { id = contractProject.Id });
        }

        public ActionResult Settlement(int id)
        {
            var contractProject = _contractProjectService.GetById(id);
            var model = Mapper.Map<ContractProject, SettlementViewModel>(contractProject);
            model.WealthValue = contractProject.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var contractProject = _contractProjectService.GetById(id);
            if (contractProject.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (contractProject.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (contractProject.ValidDate == null || ((DateTime)contractProject.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                contractProject.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                contractProject.ValidDate = ((DateTime)contractProject.ValidDate).AddDays(delayDays);
            }
            contractProject.Publisher.WealthValue -= 1 * delayDays;
            _contractProjectService.Update(contractProject);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ContractProject contractProject = _contractProjectService.GetById(id);
            if (contractProject.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var contractProjectEdit = Mapper.Map<ContractProject, ContractProjectEditViewModel>(contractProject);

            return View(contractProjectEdit);
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _contractProjectService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
