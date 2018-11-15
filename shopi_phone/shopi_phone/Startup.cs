using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shopi_phone.Startup))]
namespace shopi_phone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
