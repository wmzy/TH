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
    public class JobHuntingController : Controller
    {
        private readonly IJobHuntingService _jobHuntingService;
        public JobHuntingController(IJobHuntingService jobHuntingService)
        {
            _jobHuntingService = jobHuntingService;
        }

        //
        // GET: /JobHunting/
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;
            IEnumerable<JobHuntingIndexViewModel> jobHuntings = _jobHuntingService.Get(pageIndex, pageSize, out recordCount).Select(j => new JobHuntingIndexViewModel
            {
                Id = j.Id,
                Title = j.Title,
                CreatedDate = j.CreatedDate,
                Name = j.Name,
                Age = j.Age,
                Education = j.Education,
                Job = j.Job,
                Nation = j.Nation,
                WorkYears = j.WorkYears
            }).ToList();

            ViewData["recordCount"] = recordCount;

            return View(jobHuntings);
        }

        //
        // GET: /JobHunting/Details/5
        public ActionResult Details(int id)
        {
            JobHunting jobHunting = _jobHuntingService.GetById(id);
            var jobHuntingDetails = new JobHuntingDetailsViewModel
            {
                Id = jobHunting.Id,
                Title = jobHunting.Title,
                City = jobHunting.City,
                Publisher = jobHunting.Publisher,
                Telephones = jobHunting.Telephones,
                Views = jobHunting.Views,
                Name = jobHunting.Name,
                Nation = jobHunting.Nation,
                Age = jobHunting.Age,
                Wage = jobHunting.Wage,
                WorkYears = jobHunting.WorkYears,
                WorkExperience = jobHunting.WorkExperience,
                Education = jobHunting.Education,
                CreatedDate = jobHunting.CreatedDate,
                Job = jobHunting.Job,
                Introduction = jobHunting.Introduction
            };

            return View(jobHuntingDetails);
        }

        //
        // GET: /JobHunting/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /JobHunting/Create
        [HttpPost]
        public ActionResult Create(JobHuntingCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var job = new JobHunting
                {
                    Title = model.Title,
                    Publisher = new User {Id = User.Identity.GetUserId()},
                    CreatedDate = DateTime.Now,
                    City = ControllerContext.HttpContext.Request.UserHostAddress,
                    Telephones = model.Telephones,
                    Education = model.Education,
                    Age = model.Age,
                    Name = model.Name,
                    Job = model.Job,
                    Nation = model.Nation,
                    WorkExperience = model.WorkExperience,
                    Wage = model.Wage,
                    WorkYears = model.WorkYears,
                    Introduction = model.Introduction
                };
                _jobHuntingService.Create(job);

                return RedirectToAction("Details", new { id = job.Id });
            }

            return View(model);
        }

        //
        // GET: /JobHunting/Edit/5
        public ActionResult Edit(int id)
        {
            JobHunting jobHunting = _jobHuntingService.GetById(id);
            if (jobHunting.Publisher.Id != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var jobHuntingEdit = new JobHuntingEditViewModel
            {
                Id = jobHunting.Id,
                Title = jobHunting.Title,
                Telephones = jobHunting.Telephones,
                Name = jobHunting.Name,
                Nation = jobHunting.Nation,
                Age = jobHunting.Age,
                WorkYears = jobHunting.WorkYears,
                Education = jobHunting.Education,
                WorkExperience = jobHunting.WorkExperience,
                Job = jobHunting.Job,
                Wage = jobHunting.Wage,
                Introduction = jobHunting.Introduction
            };

            return View(jobHuntingEdit);
        }

        //
        // POST: /JobHunting/Edit/5
        [HttpPost]
        public ActionResult Edit(JobHuntingEditViewModel model)
        {
            JobHunting jobHunting = _jobHuntingService.GetById(model.Id);

            if (jobHunting.Publisher.Id != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            jobHunting.Title = model.Title;
            jobHunting.Telephones = model.Telephones;
            jobHunting.Name = model.Name;
            jobHunting.Nation = model.Nation;
            jobHunting.Age = model.Age;
            jobHunting.Education = model.Education;
            jobHunting.WorkYears = model.WorkYears;
            jobHunting.Wage = model.Wage;
            jobHunting.Job = model.Job;
            jobHunting.WorkExperience = model.WorkExperience;
            jobHunting.Introduction = model.Introduction;

            _jobHuntingService.Update(jobHunting);

            return RedirectToAction("Details", new { id = jobHunting.Id });
        }

        //
        // GET: /JobHunting/Delete/5
        public ActionResult Delete(int id)
        {
            _jobHuntingService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
    }
}
