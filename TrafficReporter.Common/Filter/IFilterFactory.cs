using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common.Filter
{
    public interface IFilterFactory
    {
        /// <summary>
        /// Gets filter. 
        /// </summary>
        /// <param name="dx">The x coordinate of lower point.</param>
        /// <param name="dy">The y coordinate of lower point.</param>
        /// <param name="ux">The x coordinate of upper point.</param>
        /// <param name="uy">The y coordinate of upper point.</param>
        /// <param name="cause">
        /// The cause is sent as a single number by which we search
        /// using flag enums. See here: https://timdams.com/2011/02/14/using-enum-flags-to-write-filters-in-linq/
        /// </param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>New filter</returns>
        IFilter GetFilter(double dx, double dy, double ux, double uy,
            int cause = 0, int pageNumber = 1, int pageSize = 10);
    }
}
