using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shopiphone.Startup))]
namespace Shopiphone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
