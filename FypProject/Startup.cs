using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FypProject.Startup))]
namespace FypProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
