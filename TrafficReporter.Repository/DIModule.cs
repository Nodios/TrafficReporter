using Ninject.Modules;
using TrafficReporter.Repository.Common;

namespace TrafficReporter.Repository
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IReportRepository>().To<ReportRepository>();
            Bind<ICauseRepository>().To<CauseRepository>();
        }
    }
}