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
    public class UseMachineController : Controller
    {
        private readonly IUseMachineService _useMachineService;
        public UseMachineController(IUseMachineService useMachineService)
        {
            _useMachineService = useMachineService;
        }

        //
        // GET: /UseMachine/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var useMachinesPage = _useMachineService.Get()
                .Project().To<UseMachineIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(useMachinesPage);
        }

        //
        // GET: /UseMachine/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            UseMachine useMachine = _useMachineService.GetById(id);
            var useMachineDetails = Mapper.Map<UseMachine, UseMachineDetailsViewModel>(useMachine);

            return View(useMachineDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UseMachineCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var useMachine = Mapper.Map<UseMachineCreateViewModel, UseMachine>(model);

            useMachine.PublisherId = User.Identity.GetUserId();
            useMachine.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _useMachineService.Create(useMachine);

            return RedirectToAction("Settlement", new { id = useMachine.Id });
        }

        public ActionResult Settlement(int id)
        {
            var useMachine = _useMachineService.GetById(id);
            var model = Mapper.Map<UseMachine, SettlementViewModel>(useMachine);
            model.WealthValue = useMachine.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var useMachine = _useMachineService.GetById(id);
            if (useMachine.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (useMachine.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (useMachine.ValidDate == null || ((DateTime)useMachine.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                useMachine.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                useMachine.ValidDate = ((DateTime)useMachine.ValidDate).AddDays(delayDays);
            }
            useMachine.Publisher.WealthValue -= 1 * delayDays;
            _useMachineService.Update(useMachine);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            UseMachine useMachine = _useMachineService.GetById(id);
            if (useMachine.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var useMachineEdit = Mapper.Map<UseMachine, UseMachineEditViewModel>(useMachine);

            return View(useMachineEdit);
        }

        [HttpPost]
        public ActionResult Edit(UseMachineEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            UseMachine useMachine = _useMachineService.GetById(model.Id);

            if (useMachine.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, useMachine);

            _useMachineService.Update(useMachine);

            return RedirectToAction("Details", new { id = useMachine.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _useMachineService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
