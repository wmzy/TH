using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<MachineIndexViewModel> machines = _machineService.Get(pageIndex, pageSize, out recordCount).Project().To<MachineIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(machines);
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

            return RedirectToAction("Details", new { id = machine.Id });
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

        public ActionResult Delete(int id)
        {
            _machineService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
    }
}
