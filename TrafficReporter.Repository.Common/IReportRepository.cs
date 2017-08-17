using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Repository.Common
{
    public interface IReportRepository
    {
        ///<summary>
        /// Adds the report to database.
        /// </summary>
        /// <param name="report">The report to be added to database.</param>
        /// <returns>Number of rows affected by removing(should be 1).</returns>
        int AddReport(IReport report);

        /// <summary>
        /// Gets report from database which has passed parameter id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Report found by passed id.</returns>
        IReport GetReport(Guid id);

        /// <summary>
        /// Removes the report from database by passing Id parameter.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>Number of rows affected by removing(should be 1).</returns>
        int RemoveReport(Guid id);
        

        

    }
}
