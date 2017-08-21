using Ninject;
using System.Collections.Generic;
using AutoMapper;
using Ninject.Modules;
using TrafficReporter.Repository.Common;
using TrafficReporter.Model;
using TrafficReporter.DAL.Entity_Models;
using TrafficReporter.Model.Common;
using TrafficReporter.Service.Common;
using TrafficReporter.Repository;

namespace TrafficReporter.Repository
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IReportRepository>().To<ReportRepository>();
        }
    }
}