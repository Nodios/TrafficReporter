using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common.Filters
{
    public interface IFilter
    {
        Location LowerLeft { get; set; }
        Location UpperRight { get; set; }
        CauseEnum Cause { get; set; }

        public string SendFilterCriteria()
        public string RetrieveFiltered()
      
    }

}
