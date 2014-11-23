using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Northwind.MVC.Startup))]
namespace Northwind.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
