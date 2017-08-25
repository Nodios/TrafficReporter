using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrafficReporter.Common.Filter
{
    public interface IFilter : IPageFilter
    {
        double LowerLeftX { get; set; }
        double LowerLeftY { get; set; }
        double UpperRightX { get; set; }
        double UpperRightY { get; set; }
        string Cause { get; set; }
        List<int> CauseCollection  { get; set; }
        

    }
}
