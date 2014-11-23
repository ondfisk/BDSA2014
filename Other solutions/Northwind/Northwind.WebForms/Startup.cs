using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Northwind.WebForms.Startup))]
namespace Northwind.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
