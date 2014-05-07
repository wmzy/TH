using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TH.Services;
using TH.WebUI.ViewModels;

namespace TH.WebUI.Controllers
{
    [Authorize]
    public class ManageInfoController : Controller
    {
        private readonly IJobService _jobService;
        public ManageInfoController(IJobService jobService)
        {
            _jobService = jobService;
        }
        //
        // GET: /ManageInfo/
        public ActionResult Index()
        {

            var jobs = _jobService.GetByUserId(User.Identity.GetUserId());
            var infoView = jobs.Select(j => new InfoViewModel
            {
                Id = j.Id,
                Title = j.Title,
                CreateDate = j.CreatedDate,
                Genre = "招聘信息",
                ControllerName = "Job"
            }).ToList();

            //infoView.AddRange(othos);

            return View(infoView);
        }

        //
        // GET: /ManageInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ManageInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManageInfo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ManageInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ManageInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ManageInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ManageInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
