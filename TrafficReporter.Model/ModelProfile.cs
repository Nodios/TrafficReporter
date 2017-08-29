using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Model
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<IReport, Report>();
            CreateMap<ICause, Cause>();
        }
    }
}
