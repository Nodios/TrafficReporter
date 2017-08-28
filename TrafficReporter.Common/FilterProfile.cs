using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TrafficReporter.Common.Filter;

namespace TrafficReporter.Common
{
    public class FilterProfile : Profile
    {
        public FilterProfile()
        {
            CreateMap<IFilter, Filters>();
            CreateMap<IPageFilter, PageFilter>();
        }
    }
}
