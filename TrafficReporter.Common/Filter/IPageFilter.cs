using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common.Filter
{
    public interface IPageFilter
    {
        string SortOrder { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }

    }
}
