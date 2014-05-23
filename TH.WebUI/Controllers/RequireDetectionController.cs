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
    public class RequireDetectionController : Controller
    {
        private readonly IRequireDetectionService _requireDetectionService;
        public RequireDetectionController(IRequireDetectionService requireDetectionService)
        {
            _requireDetectionService = requireDetectionService;
        }

        //
        // GET: /RequireDetection/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<RequireDetectionIndexViewModel> requireDetections = _requireDetectionService.Get(pageIndex, pageSize, out recordCount).Project().To<RequireDetectionIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(requireDetections);
        }

        //
        // GET: /RequireDetection/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            RequireDetection requireDetection = _requireDetectionService.GetById(id);
            var requireDetectionDetails = Mapper.Map<RequireDetection, RequireDetectionDetailsViewModel>(requireDetection);
            
            return View(requireDetectionDetails);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RequireDetectionCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var requireDetection = Mapper.Map<RequireDetectionCreateViewModel, RequireDetection>(model);

            requireDetection.PublisherId = User.Identity.GetUserId();
            requireDetection.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _requireDetectionService.Create(requireDetection);

            return RedirectToAction("Details", new { id = requireDetection.Id });
        }

        public ActionResult Edit(int id)
        {
            RequireDetection requireDetection = _requireDetectionService.GetById(id);
            if (requireDetection.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var requireDetectionEdit = Mapper.Map<RequireDetection, RequireDetectionEditViewModel>(requireDetection);
            
            return View(requireDetectionEdit);
        }

        [HttpPost]
        public ActionResult Edit(RequireDetectionEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            RequireDetection requireDetection = _requireDetectionService.GetById(model.Id);

            if (requireDetection.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, requireDetection);
            
            _requireDetectionService.Update(requireDetection);

            return RedirectToAction("Details", new { id = requireDetection.Id });
        }

        public ActionResult Delete(int id)
        {
            _requireDetectionService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
    }
}
