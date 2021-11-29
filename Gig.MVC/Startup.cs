using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gig.MVC.Startup))]
namespace Gig.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
