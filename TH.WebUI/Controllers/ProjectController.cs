using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TH.Repositories.Entities;
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
            return View();
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
            Project project = _projectService.GetProjectById(id);
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
            if (job.Publisher.Id != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var jobEdit = new JobEditViewModel
            {
                Id = project.Id,
                Company = project.Company,
                CompanyIntroduction = project.CompanyIntroduction,
                ContactPerson = project.ContactPerson,
                EducationRequire = project.EducationRequire,
                JobDescription = project.JobDescription,
                Location = project.Location,
                Name = project.Name,
                RecruitCount = project.RecruitCount,
                Requirements = project.Requirements,
                Telephones = project.Telephones,
                Title = project.Title,
                Wage = project.Wage,
                WorkYears = project.WorkYears
            };

            return View(jobEdit);
        }

        [HttpPost]
        public ActionResult Edit(JobEditViewModel model)
        {
            Project project = _projectService.GetById(model.Id);

            if (job.Publisher.Id != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            project.Title = model.Title;
            project.Company = model.Company;
            project.Name = model.Name;
            project.RecruitCount = model.RecruitCount;
            project.Location = model.Location;
            project.EducationRequire = model.EducationRequire;
            project.WorkYears = model.WorkYears;
            project.Wage = model.Wage;
            project.JobDescription = model.JobDescription;
            project.CompanyIntroduction = model.CompanyIntroduction;
            project.Requirements = model.Requirements;
            project.ContactPerson = model.ContactPerson;

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