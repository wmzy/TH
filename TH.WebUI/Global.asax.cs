using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TH.WebUI.Common;

namespace TH.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyResolverConfig.SetResolver();
            AutoMapperConfig.Configure();

            HitCounters.StartCount();
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            HitCounters.SessionStart();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            HitCounters.HitFor(Request.Url.AbsolutePath);
        }
        
        protected void Session_End(Object sender, EventArgs e)
        {
            HitCounters.SessionEnd();
        }

        protected void Application_End(Object sender, EventArgs e)
        {
            HitCounters.End();
        }
    }
}
