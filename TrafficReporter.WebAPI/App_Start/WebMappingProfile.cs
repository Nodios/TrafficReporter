using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using AutoMapper;
using TrafficReporter.Model.Common;
using TrafficReporter.WebAPI.ViewModels;

namespace TrafficReporter.WebAPI.App_Start
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<ReportViewModel, IReport>();
        }
    }
}