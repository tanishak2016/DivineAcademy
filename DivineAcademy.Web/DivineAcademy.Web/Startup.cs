using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DivineAcademy.Web.Startup))]
namespace DivineAcademy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
