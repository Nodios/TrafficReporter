using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;
using TrafficReporter.Common;

namespace TrafficReporter.Repository.Common
{
    public interface IReportRepository
    {
        ///<summary>
        /// Adds the report to database.
        /// </summary>
        /// <param name="report">The report to be added to database.</param>
        /// <returns>Number of rows affected by removing(should be 1).</returns>
        Task<int> AddReportAsync(IReport report);

        /// <summary>
        /// Gets report from database which has passed parameter id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Report found by passed id.</returns>
        Task<IReport> GetReportAsync(Guid id);

        /// <summary>
        /// Gets all reports from database which satisfy passed filter.
        /// </summary>
        /// <param name="causeFilter">Filter which report has to satisfy in order to be retrieved.</param>
        /// <returns></returns>
        Task<IEnumerable<IReport>> GetFilteredReportsAsync(ICauseFilter causeFilter);

        /// <summary>
        /// Removes the report from database by passing Id parameter.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>Number of rows affected by removing(should be 1).</returns>
        Task<int> RemoveReportAsync(Guid id);
        

        

    }
}
