using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TrafficReporter.Model;
using TrafficReporter.DAL.Entity_Models;
using TrafficReporter.Model.Common;
using TrafficReporter.Repository.Common;
using TrafficReporter.Service.Common;

namespace TrafficReporter.Repository
{
    class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportEntity, Report>();
                cfg.CreateMap<ReportEntity, IReport>();
                cfg.CreateMap<Report, IReport>();

                Bind<IReportRepository>().To<ReportRepository>();
            });
        }
    }
}
