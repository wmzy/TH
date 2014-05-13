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
            IEnumerable<JobHuntingIndexViewModel> jobHuntings = _jobHuntingService.Get(pageIndex, pageSize, out recordCount).Project().To<JobHuntingIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            return View(jobHuntings);
        }

        //
        // GET: /JobHunting/Details/5
        public ActionResult Details(int id)
        {
            JobHunting jobHunting = _jobHuntingService.GetById(id);
            var jobHuntingDetails = Mapper.Map<JobHunting, JobHuntingDetailsViewModel>(jobHunting);

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
            if (!ModelState.IsValid) return View(model);
            var job = Mapper.Map<JobHuntingCreateViewModel, JobHunting>(model);

            job.PublisherId = User.Identity.GetUserId();
            job.City = ControllerContext.HttpContext.Request.UserHostAddress;
            _jobHuntingService.Create(job);

            return RedirectToAction("Details", new { id = job.Id });
        }

        //
        // GET: /JobHunting/Edit/5
        public ActionResult Edit(int id)
        {
            JobHunting jobHunting = _jobHuntingService.GetById(id);
            if (jobHunting.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var jobHuntingEdit = Mapper.Map<JobHunting, JobHuntingEditViewModel>(jobHunting);

            return View(jobHuntingEdit);
        }

        //
        // POST: /JobHunting/Edit/5
        [HttpPost]
        public ActionResult Edit(JobHuntingEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            JobHunting jobHunting = _jobHuntingService.GetById(model.Id);

            if (jobHunting.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            Mapper.Map(model, jobHunting);

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
