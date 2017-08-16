using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Service.Common;
using TrafficReporter.Repository.Common;
using TrafficReporter.Model;
using TrafficReporter.Model.Common;
using TrafficReporter.Common.Enums;

namespace TrafficReporter.Service
{
    public class ReportService : IReportService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ReportService(IReportRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Properties




        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        protected IReportRepository Repository { get; private set; }

        public void AddReport(double Long, double Lat, Cause Cause)
        {
            
            
        }
        #endregion Properties 

        #region Methods

       
        /// <summary>
        /// Add report.
        /// </summary>
        /// <param name="">Report identifier</param>
        /// <returns></returns>
        public bool AddReport(ReportPOCO Report)
        {
            
            return true;
        }


        int upTo = 2;
        /// <summary>
        /// Gets the reports.
        /// </summary>
        /// <param name="upTo">Up to some amount of reports.</param>
        /// <returns></returns>
        public bool GetReports(int upTo)

        {
            return true;
        }

        public bool GetReport(Guid Id)
        {
            return true;
        }

        /// <summary>
        /// Removes report.
        /// </summary>
        /// <param name="Id">Report identifier.</param>
        /// <returns></returns>
        public bool RemoveReport(Guid Id)
        {
            return true;
        }

        public bool AddReport()
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}
