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
    public class MachineController : Controller
    {
        private readonly IMachineService _machineService;
        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        //
        // GET: /Machine/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var machinesPage = _machineService.Get()
                .Project().To<MachineIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(machinesPage);
        }

        //
        // GET: /Machine/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Machine machine = _machineService.GetById(id);
            var machineDetails = Mapper.Map<Machine, MachineDetailsViewModel>(machine);

            return View(machineDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MachineCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var machine = Mapper.Map<MachineCreateViewModel, Machine>(model);

            machine.PublisherId = User.Identity.GetUserId();
            machine.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _machineService.Create(machine);

            return RedirectToAction("Settlement", new { id = machine.Id });
        }

        public ActionResult Settlement(int id)
        {
            var machine = _machineService.GetById(id);
            var model = Mapper.Map<Machine, SettlementViewModel>(machine);
            model.WealthValue = machine.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var machine = _machineService.GetById(id);
            if (machine.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (machine.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (machine.ValidDate == null || ((DateTime)machine.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                machine.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                machine.ValidDate = ((DateTime)machine.ValidDate).AddDays(delayDays);
            }
            machine.Publisher.WealthValue -= 1 * delayDays;
            _machineService.Update(machine);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Machine machine = _machineService.GetById(id);
            if (machine.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var machineEdit = Mapper.Map<Machine, MachineEditViewModel>(machine);

            return View(machineEdit);
        }

        [HttpPost]
        public ActionResult Edit(MachineEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Machine machine = _machineService.GetById(model.Id);

            if (machine.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, machine);

            _machineService.Update(machine);

            return RedirectToAction("Details", new { id = machine.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _machineService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
