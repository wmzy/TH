using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Services;
using TH.Repositories.Entities;

namespace TH.WebUI.Areas.Recruitment.Controllers
{
    public class FullTimeJobController : Controller
    {
        readonly IFullTimeJobService fullTimeJobService;
        public FullTimeJobController(IFullTimeJobService fullTimeJobService)
        {
            this.fullTimeJobService = fullTimeJobService;
        }

        //
        // GET: /Recruitment/FullTimeJob/

        public ActionResult Index()
        {
            IEnumerable<FullTimeJobType> types = fullTimeJobService.GetTypes();

            //
            return View(types);
        }

        //
        // GET: /Recruitment/FullTimeJob/Type/{Id}

        public ActionResult Type(int Id)
        {
            int count;
            IEnumerable<Job> fullTimeJobs = fullTimeJobService.GetFullTimeJobsTypeId(Id, 1, 20, out count);

            ViewData["count"] = count;
            //
            return View(fullTimeJobs);
        }

        [HttpPost]
        public ActionResult Add()
        {
            return View();
        }
    }
}
