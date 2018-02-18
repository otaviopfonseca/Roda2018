using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Roda.Web.Startup))]
namespace Roda.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
