using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Common.Enums;

namespace TrafficReporter.Common.Filter
{
    public interface IFilter
    {
        double LowerLeftX { get; set; }
        double LowerLeftY { get; set; }
        double UpperRightX { get; set; }
        double UpperRightY { get; set; }
        Cause  Cause { get; set; }
        string SortOrder { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }

    }
}
