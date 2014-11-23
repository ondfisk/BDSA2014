using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lecture09.MVC.Startup))]
namespace Lecture09.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
