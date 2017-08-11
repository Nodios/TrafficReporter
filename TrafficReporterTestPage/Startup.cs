using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrafficReporterTestPage.Startup))]
namespace TrafficReporterTestPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
