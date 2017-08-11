using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrafficReporterTestWebApp.Startup))]
namespace TrafficReporterTestWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
