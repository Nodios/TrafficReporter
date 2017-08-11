using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Service.Common
{
    public interface IReportService
    {
        /// <summary>
        /// Adds report
        /// </summary>
        /// <param name="Id">Report identifier</param>
        /// <returns></returns>
        bool AddReport(Guid Id);

        /// <summary>
        /// Gets all available reports
        /// </summary>
        /// <returns></returns>
        List<IReportPOCO> GetAllAvailableReports();

        /// <summary>
        /// Removes report
        /// </summary>
        /// <param name="Id">Report identifier</param>
        /// <returns></returns>
        bool RemoveReport(Guid Id);
    }
}
