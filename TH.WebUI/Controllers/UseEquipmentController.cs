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
    public class UseEquipmentController : Controller
    {
        private readonly IUseEquipmentService _useEquipmentService;
        public UseEquipmentController(IUseEquipmentService useEquipmentService)
        {
            _useEquipmentService = useEquipmentService;
        }

        //
        // GET: /UseEquipment/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var useEquipmentsPage = _useEquipmentService.Get()
                .Project().To<UseEquipmentIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(useEquipmentsPage);
        }

        //
        // GET: /UseEquipment/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            UseEquipment useEquipment = _useEquipmentService.GetById(id);
            var useEquipmentDetails = Mapper.Map<UseEquipment, UseEquipmentDetailsViewModel>(useEquipment);

            return View(useEquipmentDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UseEquipmentCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var useEquipment = Mapper.Map<UseEquipmentCreateViewModel, UseEquipment>(model);

            useEquipment.PublisherId = User.Identity.GetUserId();
            useEquipment.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _useEquipmentService.Create(useEquipment);

            return RedirectToAction("Settlement", new { id = useEquipment.Id });
        }

        public ActionResult Settlement(int id)
        {
            var useEquipment = _useEquipmentService.GetById(id);
            var model = Mapper.Map<UseEquipment, SettlementViewModel>(useEquipment);
            model.WealthValue = useEquipment.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var useEquipment = _useEquipmentService.GetById(id);
            if (useEquipment.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (useEquipment.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (useEquipment.ValidDate == null || ((DateTime)useEquipment.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                useEquipment.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                useEquipment.ValidDate = ((DateTime)useEquipment.ValidDate).AddDays(delayDays);
            }
            useEquipment.Publisher.WealthValue -= 1 * delayDays;
            _useEquipmentService.Update(useEquipment);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            UseEquipment useEquipment = _useEquipmentService.GetById(id);
            if (useEquipment.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var useEquipmentEdit = Mapper.Map<UseEquipment, UseEquipmentEditViewModel>(useEquipment);

            return View(useEquipmentEdit);
        }

        [HttpPost]
        public ActionResult Edit(UseEquipmentEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            UseEquipment useEquipment = _useEquipmentService.GetById(model.Id);

            if (useEquipment.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, useEquipment);

            _useEquipmentService.Update(useEquipment);

            return RedirectToAction("Details", new { id = useEquipment.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _useEquipmentService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
