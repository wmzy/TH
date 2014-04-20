using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TH.Services;
using TH.WebUI.ViewModels;

namespace TH.WebUI.Controllers
{
    using TH.Repositories.Entities;
    using WebMatrix.WebData;

    [Authorize]
    public class JobController : Controller
    {
        readonly IJobService jobService;
        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        //
        // GET: /Job/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 0, int pageSize = 0)
        {
            return View();
            int recordCount;
            IEnumerable<Job> jobs = jobService.GetJobs(pageIndex, pageSize, out recordCount);

            ViewData["recordCount"] = recordCount;

            //
            return View(jobs);
        }

        //
        // GET: /Job/Home/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Job job = jobService.GetJobById(id);

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
                jobService.CreateJob(new Job { 
                    Company = m.Company,
                    CompanyIntroduction = m.CompanyIntroduction,
                    Publisher = new User {UserId = WebSecurity.CurrentUserId}
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
