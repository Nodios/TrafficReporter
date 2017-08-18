using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common
{
    public interface ICauseFilter
    {
        // incident cause filtering parameter
        CauseEnum Cause { get; set; } 

        // paging and sorting parameters
        string SortOrder { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
