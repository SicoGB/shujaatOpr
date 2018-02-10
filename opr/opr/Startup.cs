using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(opr.Startup))]
namespace opr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
