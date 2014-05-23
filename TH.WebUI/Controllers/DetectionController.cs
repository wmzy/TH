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
    public class DetectionController : Controller
    {
        private readonly IDetectionService _detectionService;
        public DetectionController(IDetectionService detectionService)
        {
            _detectionService = detectionService;
        }

        //
        // GET: /Detection/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<DetectionIndexViewModel> detections = _detectionService.Get(pageIndex, pageSize, out recordCount).Project().To<DetectionIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(detections);
        }

        //
        // GET: /Detection/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Detection detection = _detectionService.GetById(id);
            var detectionDetails = Mapper.Map<Detection, DetectionDetailsViewModel>(detection);
            
            return View(detectionDetails);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DetectionCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var detection = Mapper.Map<DetectionCreateViewModel, Detection>(model);

            detection.PublisherId = User.Identity.GetUserId();
            detection.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _detectionService.Create(detection);

            return RedirectToAction("Details", new { id = detection.Id });
        }

        public ActionResult Edit(int id)
        {
            Detection detection = _detectionService.GetById(id);
            if (detection.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var detectionEdit = Mapper.Map<Detection, DetectionEditViewModel>(detection);
            
            return View(detectionEdit);
        }

        [HttpPost]
        public ActionResult Edit(DetectionEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Detection detection = _detectionService.GetById(model.Id);

            if (detection.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, detection);
            
            _detectionService.Update(detection);

            return RedirectToAction("Details", new { id = detection.Id });
        }

        public ActionResult Delete(int id)
        {
            _detectionService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
    }
}
