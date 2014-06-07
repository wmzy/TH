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
    public class CredentialController : Controller
    {
        private readonly ICredentialService _credentialService;
        public CredentialController(ICredentialService credentialService)
        {
            _credentialService = credentialService;
        }

        //
        // GET: /Credential/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            var credentialsPage = _credentialService.Get()
                .Project().To<CredentialIndexViewModel>()
                .ToPagedList(pageIndex, pageSize);

            //
            return View(credentialsPage);
        }

        //
        // GET: /Credential/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Credential credential = _credentialService.GetById(id);
            var credentialDetails = Mapper.Map<Credential, CredentialDetailsViewModel>(credential);

            return View(credentialDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CredentialCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var credential = Mapper.Map<CredentialCreateViewModel, Credential>(model);

            credential.PublisherId = User.Identity.GetUserId();
            credential.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _credentialService.Create(credential);

            return RedirectToAction("Settlement", new { id = credential.Id });
        }

        public ActionResult Settlement(int id)
        {
            var credential = _credentialService.GetById(id);
            var model = Mapper.Map<Credential, SettlementViewModel>(credential);
            model.WealthValue = credential.Publisher.WealthValue;
            return View(model);
        }
        [HttpPost]
        public ActionResult Settlement(int id, int delayDays)
        {
            var credential = _credentialService.GetById(id);
            if (credential.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (credential.Publisher.WealthValue < 1 * delayDays)
            {
                return Json(new { result = 1, err = "财富值不足" });
            }
            if (credential.ValidDate == null || ((DateTime)credential.ValidDate).CompareTo(DateTime.Now) >= 0)
            {
                credential.ValidDate = DateTime.Now.AddDays(delayDays);
            }
            else
            {
                credential.ValidDate = ((DateTime)credential.ValidDate).AddDays(delayDays);
            }
            credential.Publisher.WealthValue -= 1 * delayDays;
            _credentialService.Update(credential);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Credential credential = _credentialService.GetById(id);
            if (credential.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var credentialEdit = Mapper.Map<Credential, CredentialEditViewModel>(credential);

            return View(credentialEdit);
        }

        [HttpPost]
        public ActionResult Edit(CredentialEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Credential credential = _credentialService.GetById(model.Id);

            if (credential.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, credential);

            _credentialService.Update(credential);

            return RedirectToAction("Details", new { id = credential.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _credentialService.OwnerDelete(User.Identity.GetUserId(), id);
            return Json(new { result = "Success" });
        }
    }
}
