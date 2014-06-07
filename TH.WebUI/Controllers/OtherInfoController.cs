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
    public class OtherInfoController : Controller
    {
        private readonly IOtherInfoService _otherInfoService;
        public OtherInfoController(IOtherInfoService otherInfoService)
        {
            _otherInfoService = otherInfoService;
        }

        //
        // GET: /OtherInfo/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var otherInfosPage = _otherInfoService.Get()
                .Project().To<OtherInfoIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(otherInfosPage);
        }

        //
        // GET: /OtherInfo/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            OtherInfo otherInfo = _otherInfoService.GetById(id);
            var otherInfoDetails = Mapper.Map<OtherInfo, OtherInfoDetailsViewModel>(otherInfo);

            return View(otherInfoDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OtherInfoCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var otherInfo = Mapper.Map<OtherInfoCreateViewModel, OtherInfo>(model);

            otherInfo.PublisherId = User.Identity.GetUserId();
            otherInfo.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _otherInfoService.Create(otherInfo);

            return RedirectToAction("Settlement", new { id = otherInfo.Id });
        }

        public ActionResult Settlement(int id)
        {
            var otherInfo = _otherInfoService.GetById(id);
            var model = Mapper.Map<OtherInfo, SettlementViewModel>(otherInfo);
            model.WealthValue = otherInfo.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var otherInfo = _otherInfoService.GetById(id);
            if (otherInfo.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (otherInfo.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (otherInfo.ValidDate == null || ((DateTime)otherInfo.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                otherInfo.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                otherInfo.ValidDate = ((DateTime)otherInfo.ValidDate).AddDays(delayDays);
            }
            otherInfo.Publisher.WealthValue -= 1 * delayDays;
            _otherInfoService.Update(otherInfo);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            OtherInfo otherInfo = _otherInfoService.GetById(id);
            if (otherInfo.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var otherInfoEdit = Mapper.Map<OtherInfo, OtherInfoEditViewModel>(otherInfo);

            return View(otherInfoEdit);
        }

        [HttpPost]
        public ActionResult Edit(OtherInfoEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            OtherInfo otherInfo = _otherInfoService.GetById(model.Id);

            if (otherInfo.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, otherInfo);

            _otherInfoService.Update(otherInfo);

            return RedirectToAction("Details", new { id = otherInfo.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _otherInfoService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
