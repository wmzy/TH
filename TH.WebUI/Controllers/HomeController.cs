using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TH.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "天鸿路桥信息网";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "联系方式";

            return View();
        }
    }
}
