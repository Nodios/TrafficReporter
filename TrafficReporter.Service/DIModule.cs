using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Service.Common;

namespace TrafficReporter.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IReportService>().To<ReportService>();
            Bind<ICauseService>().To<CauseService>();
        }
    }
}
