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
    public class FinancingController : Controller
    {
        private readonly IFinancingService _financingService;
        public FinancingController(IFinancingService financingService)
        {
            _financingService = financingService;
        }

        //
        // GET: /Financing/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var financingsPage = _financingService.Get()
                .Project().To<FinancingIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(financingsPage);
        }

        //
        // GET: /Financing/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Financing financing = _financingService.GetById(id);
            var financingDetails = Mapper.Map<Financing, FinancingDetailsViewModel>(financing);

            return View(financingDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FinancingCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var financing = Mapper.Map<FinancingCreateViewModel, Financing>(model);

            financing.PublisherId = User.Identity.GetUserId();
            financing.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _financingService.Create(financing);

            return RedirectToAction("Settlement", new { id = financing.Id });
        }

        public ActionResult Settlement(int id)
        {
            var financing = _financingService.GetById(id);
            var model = Mapper.Map<Financing, SettlementViewModel>(financing);
            model.WealthValue = financing.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var financing = _financingService.GetById(id);
            if (financing.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (financing.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (financing.ValidDate == null || ((DateTime)financing.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                financing.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                financing.ValidDate = ((DateTime)financing.ValidDate).AddDays(delayDays);
            }
            financing.Publisher.WealthValue -= 1 * delayDays;
            _financingService.Update(financing);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Financing financing = _financingService.GetById(id);
            if (financing.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var financingEdit = Mapper.Map<Financing, FinancingEditViewModel>(financing);

            return View(financingEdit);
        }

        [HttpPost]
        public ActionResult Edit(FinancingEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Financing financing = _financingService.GetById(model.Id);

            if (financing.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, financing);

            _financingService.Update(financing);

            return RedirectToAction("Details", new { id = financing.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _financingService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
