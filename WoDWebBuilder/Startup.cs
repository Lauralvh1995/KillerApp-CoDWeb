using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WoDWebBuilder.Startup))]
namespace WoDWebBuilder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
