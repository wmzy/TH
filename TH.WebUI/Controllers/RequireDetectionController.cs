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
    public class RequireDetectionController : Controller
    {
        private readonly IRequireDetectionService _requireDetectionService;
        public RequireDetectionController(IRequireDetectionService requireDetectionService)
        {
            _requireDetectionService = requireDetectionService;
        }

        //
        // GET: /RequireDetection/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var requireDetectionsPage = _requireDetectionService.Get()
                .Project().To<RequireDetectionIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(requireDetectionsPage);
        }

        //
        // GET: /RequireDetection/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            RequireDetection requireDetection = _requireDetectionService.GetById(id);
            var requireDetectionDetails = Mapper.Map<RequireDetection, RequireDetectionDetailsViewModel>(requireDetection);

            return View(requireDetectionDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RequireDetectionCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var requireDetection = Mapper.Map<RequireDetectionCreateViewModel, RequireDetection>(model);

            requireDetection.PublisherId = User.Identity.GetUserId();
            requireDetection.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _requireDetectionService.Create(requireDetection);

            return RedirectToAction("Settlement", new { id = requireDetection.Id });
        }

        public ActionResult Settlement(int id)
        {
            var requireDetection = _requireDetectionService.GetById(id);
            var model = Mapper.Map<RequireDetection, SettlementViewModel>(requireDetection);
            model.WealthValue = requireDetection.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var requireDetection = _requireDetectionService.GetById(id);
            if (requireDetection.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (requireDetection.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (requireDetection.ValidDate == null || ((DateTime)requireDetection.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                requireDetection.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                requireDetection.ValidDate = ((DateTime)requireDetection.ValidDate).AddDays(delayDays);
            }
            requireDetection.Publisher.WealthValue -= 1 * delayDays;
            _requireDetectionService.Update(requireDetection);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            RequireDetection requireDetection = _requireDetectionService.GetById(id);
            if (requireDetection.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var requireDetectionEdit = Mapper.Map<RequireDetection, RequireDetectionEditViewModel>(requireDetection);

            return View(requireDetectionEdit);
        }

        [HttpPost]
        public ActionResult Edit(RequireDetectionEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            RequireDetection requireDetection = _requireDetectionService.GetById(model.Id);

            if (requireDetection.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, requireDetection);

            _requireDetectionService.Update(requireDetection);

            return RedirectToAction("Details", new { id = requireDetection.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _requireDetectionService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
