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
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var jobsPage = _jobService.Get()
                .Project().To<JobIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(jobsPage);
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

            return RedirectToAction("Settlement", new { id = job.Id });
        }

        public ActionResult Settlement(int id)
        {
            var job = _jobService.GetById(id);
            var model = Mapper.Map<Job, SettlementViewModel>(job);
            model.WealthValue = job.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var job = _jobService.GetById(id);
            if (job.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (job.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new {result = 1, err = "财富值不足"});
            }
            if (job.ValidDate == null || ((DateTime)job.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                job.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                job.ValidDate = ((DateTime)job.ValidDate).AddDays(delayDays);
            }
            job.Publisher.WealthValue -= 1*delayDays;
            _jobService.Update(job);
            return RedirectToAction("Index");
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _jobService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
