using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common
{
    public interface ICauseFilter
    {
        CauseEnum Cause { get; set; }
        string SortOrder { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
