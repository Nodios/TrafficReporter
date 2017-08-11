using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Model;
using TrafficReporter.DAL.Entity_Models;
using TrafficReporter.Model.Common;


namespace TrafficReporter.Repository
{
    class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            AutoMapper.Mapper.CreateMap<ReportPOCO, Report>();
            AutoMapper.Mapper.CreateMap<ReportPOCO, IReportPOCO>();
            AutoMapper.Mapper.CreateMap<Report, IReportPOCO>();
        }
    }
}
