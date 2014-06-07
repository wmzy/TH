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
    public class RequireCredentialController : Controller
    {
        private readonly IRequireCredentialService _requireCredentialService;
        public RequireCredentialController(IRequireCredentialService requireCredentialService)
        {
            _requireCredentialService = requireCredentialService;
        }

        //
        // GET: /RequireCredential/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var requireCredentialsPage = _requireCredentialService.Get()
                .Project().To<RequireCredentialIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(requireCredentialsPage);
        }

        //
        // GET: /RequireCredential/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            RequireCredential requireCredential = _requireCredentialService.GetById(id);
            var requireCredentialDetails = Mapper.Map<RequireCredential, RequireCredentialDetailsViewModel>(requireCredential);

            return View(requireCredentialDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RequireCredentialCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var requireCredential = Mapper.Map<RequireCredentialCreateViewModel, RequireCredential>(model);

            requireCredential.PublisherId = User.Identity.GetUserId();
            requireCredential.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _requireCredentialService.Create(requireCredential);

            return RedirectToAction("Settlement", new { id = requireCredential.Id });
        }

        public ActionResult Settlement(int id)
        {
            var requireCredential = _requireCredentialService.GetById(id);
            var model = Mapper.Map<RequireCredential, SettlementViewModel>(requireCredential);
            model.WealthValue = requireCredential.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var requireCredential = _requireCredentialService.GetById(id);
            if (requireCredential.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (requireCredential.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (requireCredential.ValidDate == null || ((DateTime)requireCredential.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                requireCredential.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                requireCredential.ValidDate = ((DateTime)requireCredential.ValidDate).AddDays(delayDays);
            }
            requireCredential.Publisher.WealthValue -= 1 * delayDays;
            _requireCredentialService.Update(requireCredential);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            RequireCredential requireCredential = _requireCredentialService.GetById(id);
            if (requireCredential.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var requireCredentialEdit = Mapper.Map<RequireCredential, RequireCredentialEditViewModel>(requireCredential);

            return View(requireCredentialEdit);
        }

        [HttpPost]
        public ActionResult Edit(RequireCredentialEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            RequireCredential requireCredential = _requireCredentialService.GetById(model.Id);

            if (requireCredential.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, requireCredential);

            _requireCredentialService.Update(requireCredential);

            return RedirectToAction("Details", new { id = requireCredential.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _requireCredentialService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
