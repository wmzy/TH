﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TH.Services;
using TH.WebUI.ViewModels;
using Microsoft.AspNet.Identity;

namespace TH.WebUI.Controllers
{
    using TH.Repositories.Entities;

    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        //
        // GET: /Job/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            int recordCount;

            IEnumerable<JobIndexViewModel> jobs = _jobService.GetJobs(pageIndex, pageSize, out recordCount).Select(j => new JobIndexViewModel
            {
                Id = j.Id,
                Title = j.Title,
                Company = j.Company,
                CreatedDate = j.CreatedDate,
                Name = j.Name,
                RecruitCount = j.RecruitCount,
                Wage = j.Wage,
                Location = j.Location
            }).ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(jobs);
        }

        //
        // GET: /Job/Home/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Job job = _jobService.GetJobById(id);

            //
            return View(job);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(JobCreateViewModel m)
        {
            if (ModelState.IsValid)
            {
                _jobService.CreateJob(new Job { 
                    Title = m.Title,
                    Company = m.Company,
                    CompanyIntroduction = m.CompanyIntroduction,
                    Publisher = new User { Id = User.Identity.GetUserId()},
                    CreatedDate = DateTime.Now,
                    City = ControllerContext.HttpContext.Request.UserHostAddress
                });
            }
            return View(m);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}