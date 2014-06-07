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
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        //
        // GET: /Project/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var projectsPage = _projectService.Get()
                .Project().To<ProjectIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(projectsPage);
        }

        //
        // GET: /Project/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Project project = _projectService.GetById(id);
            var projectDetails = Mapper.Map<Project, ProjectDetailsViewModel>(project);

            return View(projectDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var project = Mapper.Map<ProjectCreateViewModel, Project>(model);

            project.PublisherId = User.Identity.GetUserId();
            project.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _projectService.Create(project);

            return RedirectToAction("Settlement", new { id = project.Id });
        }

        public ActionResult Settlement(int id)
        {
            var project = _projectService.GetById(id);
            var model = Mapper.Map<Project, SettlementViewModel>(project);
            model.WealthValue = project.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var project = _projectService.GetById(id);
            if (project.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (project.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (project.ValidDate == null || ((DateTime)project.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                project.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                project.ValidDate = ((DateTime)project.ValidDate).AddDays(delayDays);
            }
            project.Publisher.WealthValue -= 1 * delayDays;
            _projectService.Update(project);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Project project = _projectService.GetById(id);
            if (project.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var projectEdit = Mapper.Map<Project, ProjectEditViewModel>(project);

            return View(projectEdit);
        }

        [HttpPost]
        public ActionResult Edit(ProjectEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Project project = _projectService.GetById(model.Id);

            if (project.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, project);

            _projectService.Update(project);

            return RedirectToAction("Details", new { id = project.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _projectService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
