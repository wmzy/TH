using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TH.WebUI.Startup))]
namespace TH.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
