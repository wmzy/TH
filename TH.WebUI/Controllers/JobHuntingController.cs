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
    public class JobHuntingController : Controller
    {
        private readonly IJobHuntingService _jobHuntingService;
        public JobHuntingController(IJobHuntingService jobHuntingService)
        {
            _jobHuntingService = jobHuntingService;
        }

        //
        // GET: /JobHunting/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var jobHuntingsPage = _jobHuntingService.Get()
                .Project().To<JobHuntingIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(jobHuntingsPage);
        }

        //
        // GET: /JobHunting/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            JobHunting jobHunting = _jobHuntingService.GetById(id);
            var jobHuntingDetails = Mapper.Map<JobHunting, JobHuntingDetailsViewModel>(jobHunting);

            return View(jobHuntingDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(JobHuntingCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var jobHunting = Mapper.Map<JobHuntingCreateViewModel, JobHunting>(model);

            jobHunting.PublisherId = User.Identity.GetUserId();
            jobHunting.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _jobHuntingService.Create(jobHunting);

            return RedirectToAction("Settlement", new { id = jobHunting.Id });
        }

        public ActionResult Settlement(int id)
        {
            var jobHunting = _jobHuntingService.GetById(id);
            var model = Mapper.Map<JobHunting, SettlementViewModel>(jobHunting);
            model.WealthValue = jobHunting.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var jobHunting = _jobHuntingService.GetById(id);
            if (jobHunting.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (jobHunting.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (jobHunting.ValidDate == null || ((DateTime)jobHunting.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                jobHunting.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                jobHunting.ValidDate = ((DateTime)jobHunting.ValidDate).AddDays(delayDays);
            }
            jobHunting.Publisher.WealthValue -= 1 * delayDays;
            _jobHuntingService.Update(jobHunting);
            return RedirectToAction("Index");
        }

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _jobHuntingService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
