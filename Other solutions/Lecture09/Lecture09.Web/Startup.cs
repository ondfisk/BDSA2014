using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lecture09.Web.Startup))]
namespace Lecture09.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
