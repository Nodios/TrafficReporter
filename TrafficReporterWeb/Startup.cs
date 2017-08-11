using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrafficReporterWeb.Startup))]
namespace TrafficReporterWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
