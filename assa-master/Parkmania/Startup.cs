using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parkmania.Startup))]
namespace Parkmania
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
