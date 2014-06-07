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
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        //
        // GET: /Equipment/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var equipmentsPage = _equipmentService.Get()
                .Project().To<EquipmentIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(equipmentsPage);
        }

        //
        // GET: /Equipment/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Equipment equipment = _equipmentService.GetById(id);
            var equipmentDetails = Mapper.Map<Equipment, EquipmentDetailsViewModel>(equipment);

            return View(equipmentDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EquipmentCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var equipment = Mapper.Map<EquipmentCreateViewModel, Equipment>(model);

            equipment.PublisherId = User.Identity.GetUserId();
            equipment.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _equipmentService.Create(equipment);

            return RedirectToAction("Settlement", new { id = equipment.Id });
        }

        public ActionResult Settlement(int id)
        {
            var equipment = _equipmentService.GetById(id);
            var model = Mapper.Map<Equipment, SettlementViewModel>(equipment);
            model.WealthValue = equipment.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var equipment = _equipmentService.GetById(id);
            if (equipment.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (equipment.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (equipment.ValidDate == null || ((DateTime)equipment.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                equipment.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                equipment.ValidDate = ((DateTime)equipment.ValidDate).AddDays(delayDays);
            }
            equipment.Publisher.WealthValue -= 1 * delayDays;
            _equipmentService.Update(equipment);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Equipment equipment = _equipmentService.GetById(id);
            if (equipment.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var equipmentEdit = Mapper.Map<Equipment, EquipmentEditViewModel>(equipment);

            return View(equipmentEdit);
        }

        [HttpPost]
        public ActionResult Edit(EquipmentEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Equipment equipment = _equipmentService.GetById(model.Id);

            if (equipment.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, equipment);

            _equipmentService.Update(equipment);

            return RedirectToAction("Details", new { id = equipment.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _equipmentService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
