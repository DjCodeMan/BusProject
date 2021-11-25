using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusProject.Startup))]
namespace BusProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
