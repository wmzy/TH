using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Services;

namespace TH.WebUI.Controllers
{
    public class ContractProjectController : Controller
    {
        private readonly IContractProjectService _contractProjectService;
        public ContractProjectController(IContractProjectService contractProjectService)
        {
            _contractProjectService = contractProjectService;
        }

        //
        // GET: /ContractProject/
        public ActionResult Index()
        {
            return View();
        }
	}
}