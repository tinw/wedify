using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wedify.Startup))]
namespace Wedify
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
