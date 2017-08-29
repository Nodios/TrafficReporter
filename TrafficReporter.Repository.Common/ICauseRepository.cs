using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Repository.Common
{
    public interface ICauseRepository
    {
        /// <summary>
        /// This method is used by ICauseService to get icons.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ICause>> GetCausesAsync();
    }
}
