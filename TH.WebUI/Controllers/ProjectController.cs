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
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<ProjectIndexViewModel> projects = _projectService.Get(pageIndex, pageSize, out recordCount).Project().To<ProjectIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(projects);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var pro = Mapper.Map<ProjectCreateViewModel, Project>(model);
            pro.PublisherId = User.Identity.GetUserId();
            pro.City = ControllerContext.HttpContext.Request.UserHostAddress;
            _projectService.Create(pro);

            return RedirectToAction("Details", new { id = pro.Id });
        }

        //
        // GET: /Project/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Project project = _projectService.GetById(id);
            var proDetails = Mapper.Map<Project, ProjectDetailsViewModel>(project);

            return View(proDetails);
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

        public ActionResult Delete(int id)
        {
            _projectService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
	}
}