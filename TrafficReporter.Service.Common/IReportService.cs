using System;
using TrafficReporter.Model;
using TrafficReporter.Model.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrafficReporter.Common;
using TrafficReporter.Common.Filter;

namespace TrafficReporter.Service.Common
{
    public interface IReportService
    {
        /// <summary>
        /// Adds report trough repository method.
        /// Also if something happens during add, this method can throw exception
        /// and methods invoking this can respond to that.
        /// </summary>
        /// <param name="report"></param>
        /// <returns>True or false depending on operation success.</returns>
        Task<bool> AddReportAsync(IReport report);

        /// <summary>
        /// Gets report trough repository from database.
        /// </summary>
        /// <param name="id">Identifier which is criteria for searching through database.</param>
        /// <returns>Report with the given id.</returns>
        Task<IReport> GetReportAsync(Guid id);

        /// <summary>
        /// Removes report from database trough repository method.
        /// </summary>
        /// <param name="id">Report identifier.</param>
        /// <returns>True or false depending on operation success.</returns>
        Task<int> RemoveReportAsync(Guid id);

        Task<IEnumerable<IReport>> GetFilteredReportsAsync(IFilter filter=null, IPageFilter pagefilter=null);

        
    }
}