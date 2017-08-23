using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Common.Enums;

namespace TrafficReporter.Common.Filter
{
    public interface IFilter : IPageFilter
    {
        double LowerLeftX { get; set; }
        double LowerLeftY { get; set; }
        double UpperRightX { get; set; }
        double UpperRightY { get; set; }
        Cause  Cause { get; set; }
        

    }
}
