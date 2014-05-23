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
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<RequireCredentialIndexViewModel> requireCredentials = _requireCredentialService.Get(pageIndex, pageSize, out recordCount).Project().To<RequireCredentialIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(requireCredentials);
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

            return RedirectToAction("Details", new { id = requireCredential.Id });
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

        public ActionResult Delete(int id)
        {
            _requireCredentialService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
    }
}
