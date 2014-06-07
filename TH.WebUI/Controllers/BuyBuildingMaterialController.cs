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
    public class BuyBuildingMaterialController : Controller
    {
        private readonly IBuyBuildingMaterialService _buyBuildingMaterialService;
        public BuyBuildingMaterialController(IBuyBuildingMaterialService buyBuildingMaterialService)
        {
            _buyBuildingMaterialService = buyBuildingMaterialService;
        }

        //
        // GET: /BuyBuildingMaterial/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var buyBuildingMaterialsPage = _buyBuildingMaterialService.Get()
                .Project().To<BuyBuildingMaterialIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(buyBuildingMaterialsPage);
        }

        //
        // GET: /BuyBuildingMaterial/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            BuyBuildingMaterial buyBuildingMaterial = _buyBuildingMaterialService.GetById(id);
            var buyBuildingMaterialDetails = Mapper.Map<BuyBuildingMaterial, BuyBuildingMaterialDetailsViewModel>(buyBuildingMaterial);

            return View(buyBuildingMaterialDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BuyBuildingMaterialCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var buyBuildingMaterial = Mapper.Map<BuyBuildingMaterialCreateViewModel, BuyBuildingMaterial>(model);

            buyBuildingMaterial.PublisherId = User.Identity.GetUserId();
            buyBuildingMaterial.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _buyBuildingMaterialService.Create(buyBuildingMaterial);

            return RedirectToAction("Settlement", new { id = buyBuildingMaterial.Id });
        }

        public ActionResult Settlement(int id)
        {
            var buyBuildingMaterial = _buyBuildingMaterialService.GetById(id);
            var model = Mapper.Map<BuyBuildingMaterial, SettlementViewModel>(buyBuildingMaterial);
            model.WealthValue = buyBuildingMaterial.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var buyBuildingMaterial = _buyBuildingMaterialService.GetById(id);
            if (buyBuildingMaterial.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (buyBuildingMaterial.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (buyBuildingMaterial.ValidDate == null || ((DateTime)buyBuildingMaterial.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                buyBuildingMaterial.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                buyBuildingMaterial.ValidDate = ((DateTime)buyBuildingMaterial.ValidDate).AddDays(delayDays);
            }
            buyBuildingMaterial.Publisher.WealthValue -= 1 * delayDays;
            _buyBuildingMaterialService.Update(buyBuildingMaterial);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            BuyBuildingMaterial buyBuildingMaterial = _buyBuildingMaterialService.GetById(id);
            if (buyBuildingMaterial.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var buyBuildingMaterialEdit = Mapper.Map<BuyBuildingMaterial, BuyBuildingMaterialEditViewModel>(buyBuildingMaterial);

            return View(buyBuildingMaterialEdit);
        }

        [HttpPost]
        public ActionResult Edit(BuyBuildingMaterialEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            BuyBuildingMaterial buyBuildingMaterial = _buyBuildingMaterialService.GetById(model.Id);

            if (buyBuildingMaterial.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, buyBuildingMaterial);

            _buyBuildingMaterialService.Update(buyBuildingMaterial);

            return RedirectToAction("Details", new { id = buyBuildingMaterial.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _buyBuildingMaterialService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
