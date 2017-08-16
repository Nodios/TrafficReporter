using System;
using System.Collections.Generic;
using TrafficReporter.DAL.Entity_Models;

namespace TrafficReporter.DAL
{
    public interface IReportContext
    {
        #region Properties


        /// <summary>
        /// Gets or sets the reports.
        /// </summary>
        /// <value>
        /// The reports.
        /// </value>
        List<Report> Reports { get; set; }

        #endregion Properties
    }
}