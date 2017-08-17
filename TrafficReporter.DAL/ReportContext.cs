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
            Reports = new List<ReportEntity>() {
                new ReportEntity()
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
        public List<ReportEntity> Reports { get; set; }

        #endregion Properties
    }
}