using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            IEnumerable<ProjectIndexViewModel> projects = _projectService.Get().Project().To<ProjectIndexViewModel>().ToList();
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

            var pro = new Project
            {
                Title = model.Title,
                Company = model.Company,
                Publisher = new User { Id = User.Identity.GetUserId() },
                CreatedDate = DateTime.Now,
                City = ControllerContext.HttpContext.Request.UserHostAddress,
                ContactPerson = model.ContactPerson,
                Telephones = model.Telephones
            };
            _projectService.Create(pro);

            return RedirectToAction("Details", new { id = pro.Id });
        }

        //
        // GET: /Project/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Project project = _projectService.GetById(id);
            var proDetails = new ProjectDetailsViewModel()
            {
                Company = project.Company,
                City = project.City,
                ContactPerson = project.ContactPerson,
                ProjectName = project.ProjectName,
                Require = project.Require,
                StartTime = project.StartTime,
                TimeLimit = project.TimeLimit,
                Title = project.Title,
                Telephones = project.Telephones
            };

            return View(proDetails);
        }


        public ActionResult Edit(int id)
        {
            Project project = _projectService.GetById(id);
            if (project.Publisher.Id != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var projectEdit = new ProjectEditViewModel
            {
                Id = project.Id,
                Company = project.Company,
                City = project.City,
                ContactPerson = project.ContactPerson,
                ProjectName = project.ProjectName,
                Require = project.Require,
                StartTime = project.StartTime,
                TimeLimit = project.TimeLimit,
                ValidDate = project.ValidDate,
                Telephones = project.Telephones,
                Title = project.Title,
                Content = project.Content
            };

            return View(projectEdit);
        }

        [HttpPost]
        public ActionResult Edit(ProjectEditViewModel model)
        {
            Project project = _projectService.GetById(model.Id);

            if (project.Publisher.Id != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            project.Id = model.Id;
            project.Company = model.Company;
            project.City = model.City;
            project.ContactPerson = model.ContactPerson;
            project.ProjectName = model.ProjectName;
            project.Require = model.Require;
            project.StartTime = model.StartTime;
            project.TimeLimit = model.TimeLimit;
            project.ValidDate = model.ValidDate;
            project.Telephones = model.Telephones;
            project.Title = model.Title;
            project.Content = model.Content;

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