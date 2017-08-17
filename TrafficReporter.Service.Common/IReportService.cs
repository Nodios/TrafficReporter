using System;
using TrafficReporter.Model;
using TrafficReporter.Model.Common;

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
        /// <returns></returns>
        bool AddReport(IReport report);


        /// <summary>
        /// Removes report from database trough repository method.
        /// </summary>
        /// <param name="id">Report identifier.</param>
        /// <returns></returns>
        bool RemoveReport(Guid id);
    }
}