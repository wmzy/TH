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
    public class OtherInfoController : Controller
    {
        private readonly IOtherInfoService _otherInfoService;
        public OtherInfoController(IOtherInfoService otherInfoService)
        {
            _otherInfoService = otherInfoService;
        }

        //
        // GET: /OtherInfo/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<OtherInfoIndexViewModel> otherInfos = _otherInfoService.Get(pageIndex, pageSize, out recordCount).Project().To<OtherInfoIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(otherInfos);
        }

        //
        // GET: /OtherInfo/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            OtherInfo otherInfo = _otherInfoService.GetById(id);
            var otherInfoDetails = Mapper.Map<OtherInfo, OtherInfoDetailsViewModel>(otherInfo);
            
            return View(otherInfoDetails);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OtherInfoCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var otherInfo = Mapper.Map<OtherInfoCreateViewModel, OtherInfo>(model);

            otherInfo.PublisherId = User.Identity.GetUserId();
            otherInfo.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _otherInfoService.Create(otherInfo);

            return RedirectToAction("Details", new { id = otherInfo.Id });
        }

        public ActionResult Edit(int id)
        {
            OtherInfo otherInfo = _otherInfoService.GetById(id);
            if (otherInfo.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var otherInfoEdit = Mapper.Map<OtherInfo, OtherInfoEditViewModel>(otherInfo);
            
            return View(otherInfoEdit);
        }

        [HttpPost]
        public ActionResult Edit(OtherInfoEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            OtherInfo otherInfo = _otherInfoService.GetById(model.Id);

            if (otherInfo.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, otherInfo);
            
            _otherInfoService.Update(otherInfo);

            return RedirectToAction("Details", new { id = otherInfo.Id });
        }

        public ActionResult Delete(int id)
        {
            _otherInfoService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
    }
}
