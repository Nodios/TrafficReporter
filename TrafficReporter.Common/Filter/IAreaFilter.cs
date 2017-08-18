using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common
{
    public interface IAreaFilter
    {

        // map coordinates defined by the furthermost lower left point in the map view in application
        double LowerLeftX { get; set; }
        double LowerLeftY { get; set; }

        // map coordinates defined by the furthermost upper right point in the map view in application
        double UpperRightX { get; set; }
        double UpperRightY { get; set; }

        // sorting and paging parameters
        string SortOrder { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }

}
