using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Service.Common
{
    public interface ICauseService
    {
        /// <summary>
        /// Gets all causes. Used for startup on angular app.
        /// </summary>
        /// <returns>All causes from database</returns>
        Task<IEnumerable<ICause>> GetCausesAsync();
    }
}
