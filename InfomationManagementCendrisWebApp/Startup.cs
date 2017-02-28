using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfomationManagementCendrisWebApp.Startup))]
namespace InfomationManagementCendrisWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
