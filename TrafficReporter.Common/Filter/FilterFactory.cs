using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common.Filter
{
    class FilterFactory : IFilterFactory

    {
        public IFilter GetFilter(double dx, double dy, double ux, double uy, int cause = 0, int pageNumber = 1, int pageSize = 10)
        {
            return new Filters(dx, dy, ux, uy, cause, pageNumber, pageSize);
        }
    }
}
