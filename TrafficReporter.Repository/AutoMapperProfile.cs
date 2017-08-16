using AutoMapper;
using TrafficReporter.DAL.Entity_Models;
using TrafficReporter.Model;
using TrafficReporter.Model.Common;
using Ninject;


namespace TrafficReporter.Repository
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ReportEntity, Report>().ReverseMap();
            CreateMap<ReportEntity, IReport>().ReverseMap();
            CreateMap<IReport, Report>().ReverseMap();

            
            
        }

    }
}
