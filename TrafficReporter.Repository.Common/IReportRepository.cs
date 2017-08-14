using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Repository.Common
{
    public interface IReportRepository
    {
        /// <summary>
        /// Adds the report.
        /// </summary>
        /// <param name="report">The report.</param>
        /// <returns></returns>
        bool AddReport(IReportPOCO report);

        /// <summary>
        /// Removes the report.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        bool RemoveReport(Guid Id);
        
    }
}
