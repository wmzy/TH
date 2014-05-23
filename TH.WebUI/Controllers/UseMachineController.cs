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
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<UseMachineIndexViewModel> useMachines = _useMachineService.Get(pageIndex, pageSize, out recordCount).Project().To<UseMachineIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(useMachines);
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

            return RedirectToAction("Details", new { id = useMachine.Id });
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

        public ActionResult Delete(int id)
        {
            _useMachineService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
    }
}
