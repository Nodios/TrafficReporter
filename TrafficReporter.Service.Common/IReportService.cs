using System;
using TrafficReporter.Model;

namespace TrafficReporter.Service.Common
{
    public interface IReportService
    {
     /// <summary>
     /// Adds report.
     /// </summary>
     /// <param name=""></param>
     /// <returns></returns>
        bool AddReport();


        /// <summary>
        /// Removes report.
        /// </summary>
        /// <param name="Id">Report identifier.</param>
        /// <returns></returns>
        bool RemoveReport(Guid Id);

        

    }
}
