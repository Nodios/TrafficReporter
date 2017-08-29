using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common.Filter
{
    public class PageFilter :IPageFilter
    {
        public string SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int DefaultPageSize = 10;





        public PageFilter ()
        {
           
        }

    }
}
