using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TH.Model;
using TH.Services;
using TH.WebUI.ViewModels;
using Microsoft.AspNet.Identity;

namespace TH.WebUI.Controllers
{
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
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<JobIndexViewModel> jobs = _jobService.Get(pageIndex, pageSize, out recordCount).Project().To<JobIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(jobs);
        }

        //
        // GET: /Job/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Job job = _jobService.GetById(id);
            var jobDetails = Mapper.Map<Job, JobDetailsViewModel>(job);
            
            return View(jobDetails);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(JobCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var job = Mapper.Map<JobCreateViewModel, Job>(model);

            job.PublisherId = User.Identity.GetUserId();
            job.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _jobService.Create(job);

            return RedirectToAction("Details", new { id = job.Id });
        }

        public ActionResult Edit(int id)
        {
            Job job = _jobService.GetById(id);
            if (job.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var jobEdit = Mapper.Map<Job, JobEditViewModel>(job);
            
            return View(jobEdit);
        }

        [HttpPost]
        public ActionResult Edit(JobEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Job job = _jobService.GetById(model.Id);

            if (job.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, job);
            
            _jobService.Update(job);

            return RedirectToAction("Details", new { id = job.Id });
        }

        public ActionResult Delete(int id)
        {
            _jobService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
    }
}
