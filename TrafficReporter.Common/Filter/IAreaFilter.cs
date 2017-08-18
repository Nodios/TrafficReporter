using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common
{
    public interface IAreaFilter
    {
        double LowerLeftX { get; set; }
        double LowerLeftY { get; set; }
        double UpperRightX { get; set; }
        double UpperRightY { get; set; }

        string SortOrder { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }

}
