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
    public class BuildingMaterialController : Controller
    {
        private readonly IBuildingMaterialService _buildingMaterialService;
        public BuildingMaterialController(IBuildingMaterialService buildingMaterialService)
        {
            _buildingMaterialService = buildingMaterialService;
        }

        //
        // GET: /BuildingMaterial/

        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int recordCount;

            IEnumerable<BuildingMaterialIndexViewModel> buildingMaterials = _buildingMaterialService.Get(pageIndex, pageSize, out recordCount).Project().To<BuildingMaterialIndexViewModel>().ToList();

            ViewData["recordCount"] = recordCount;

            //
            return View(buildingMaterials);
        }

        //
        // GET: /BuildingMaterial/Details/{id}

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            BuildingMaterial buildingMaterial = _buildingMaterialService.GetById(id);
            var buildingMaterialDetails = Mapper.Map<BuildingMaterial, BuildingMaterialDetailsViewModel>(buildingMaterial);
            
            return View(buildingMaterialDetails);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BuildingMaterialCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var buildingMaterial = Mapper.Map<BuildingMaterialCreateViewModel, BuildingMaterial>(model);

            buildingMaterial.PublisherId = User.Identity.GetUserId();
            buildingMaterial.City = ControllerContext.HttpContext.Request.UserHostAddress;

            _buildingMaterialService.Create(buildingMaterial);

            return RedirectToAction("Details", new { id = buildingMaterial.Id });
        }

        public ActionResult Edit(int id)
        {
            BuildingMaterial buildingMaterial = _buildingMaterialService.GetById(id);
            if (buildingMaterial.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            var buildingMaterialEdit = Mapper.Map<BuildingMaterial, BuildingMaterialEditViewModel>(buildingMaterial);
            
            return View(buildingMaterialEdit);
        }

        [HttpPost]
        public ActionResult Edit(BuildingMaterialEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            BuildingMaterial buildingMaterial = _buildingMaterialService.GetById(model.Id);

            if (buildingMaterial.PublisherId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            Mapper.Map(model, buildingMaterial);
            
            _buildingMaterialService.Update(buildingMaterial);

            return RedirectToAction("Details", new { id = buildingMaterial.Id });
        }

        public ActionResult Delete(int id)
        {
            _buildingMaterialService.OwnerDelete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }
    }
}
