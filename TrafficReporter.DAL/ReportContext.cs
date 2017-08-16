using System;
using System.Collections.Generic;
using TrafficReporter.DAL.Entity_Models;

namespace TrafficReporter.DAL
{
    public class ReportContext : IReportContext
    {
        #region Constructors

        public ReportContext()
        {
            Reports = new List<Report>() {
                new Report()
                {

                }
            };
        }

        #endregion Constructors

        #region Properties


        /// <summary>
        /// Gets or sets the reports.
        /// </summary>
        /// <value>
        /// The reports.
        /// </value>
        public List<Report> Reports { get; set; }

        #endregion Properties
    }
}