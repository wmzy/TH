using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Repositories.Entities;
using TH.Services;
using TH.WebUI.Areas.Recruitment.Models;
using TH.WebUI.Filters;
using WebMatrix.WebData;

namespace TH.WebUI.Areas.Recruitment.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class CompanyController : Controller
    {
        private readonly IFullTimeJobService fullTimeJobService;
        public CompanyController(IFullTimeJobService fullTimeJobService)
        {
            this.fullTimeJobService = fullTimeJobService;
        }

        //
        // GET: /Recruitment/Company/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Recruitment/Company/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Recruitment/Company/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Recruitment/Company/Create

        [HttpPost]
        public ActionResult Create(JobModel companyModel)
        {
            try
            {
                fullTimeJobService.AddCompany(new Company
                {
                    Name = companyModel.Name,
                    NickName = companyModel.NickName,
                    Address = companyModel.Address,
                    Introduction = companyModel.Introduction,
                    LegalPerson = companyModel.LegalPerson,
                    Manager = new User {UserId =  WebSecurity.CurrentUserId}
                });

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Recruitment/Company/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Recruitment/Company/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, JobModel c)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Recruitment/Company/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Recruitment/Company/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, JobModel c)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
