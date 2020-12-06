using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EStore2.Startup))]
namespace EStore2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
