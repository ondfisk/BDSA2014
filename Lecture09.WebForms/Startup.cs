using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lecture09.WebForms.Startup))]
namespace Lecture09.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
