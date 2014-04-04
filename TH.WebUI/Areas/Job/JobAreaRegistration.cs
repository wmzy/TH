using System.Web.Mvc;

namespace TH.WebUI.Areas.Recruitment
{
    public class JobAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Job";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Job_default",
                "Job/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
