using TrafficReporter.DAL;
using TrafficReporter.Model;
using TrafficReporter.Model.Common;
using TrafficReporter.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Report.Repository
{
    public class ReportRepository : IReportRepository
    {
        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="ReportRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ReportRepository(IReportContext context)
        {
            this.Context = context;
        }

        #endregion Constructors

        #region Properties


        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        protected IReportContext Context { get; private set; }

        #endregion Properties

        #region Methods


        /// <summary>
        /// Adds the report.
        /// </summary>
        /// <returns></returns>
        public bool AddReport(IReportPOCO report)
        {
            
            return true;
        }


        public bool RemoveReport(Guid Id)
        {
            return Context.Reports.Remove(Context.Reports.First(p => p.Id.Equals(Id)));
        }

        #endregion Methods
    }
}