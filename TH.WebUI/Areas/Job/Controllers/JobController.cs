using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Services;
using TH.WebUI.Areas.Job.ViewModels;

namespace TH.WebUI.Areas.Job.Controllers
{
    using TH.Repositories.Entities;

    public class JobController : Controller
    {
        readonly IJobService jobService;
        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        //
        // GET: /Job/

        public ActionResult Index(int id, int pageIndex, int pageSize)
        {
            int? recordCount;
            IEnumerable<Job> jobs = jobService.GetJobs(id, pageIndex, pageSize, out recordCount);

            ViewData["recordCount"] = recordCount;

            //
            return View(jobs);
        }

        //
        // GET: /Job/Home/Details/{id}

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
