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
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<FinancingIndexViewModel> financings = _financingService.Get(pageIndex, pageSize, out recordCount).Project().To<FinancingIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(financings);
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

            return RedirectToAction("Details", new { id = financing.Id });
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

        public ActionResult Delete(int id)
        {
            _financingService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
    }
}
