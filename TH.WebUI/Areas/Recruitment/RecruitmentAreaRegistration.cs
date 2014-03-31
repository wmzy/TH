using System.Web.Mvc;

namespace TH.WebUI.Areas.Recruitment
{
    public class RecruitmentAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Recruitment";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Recruitment_default",
                "Recruitment/{controller}/{action}/{id}",
                new { controller = "FullTimeJob", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
