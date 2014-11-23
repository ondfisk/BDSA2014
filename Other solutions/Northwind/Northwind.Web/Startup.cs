using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Northwind.Web.Startup))]
namespace Northwind.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
