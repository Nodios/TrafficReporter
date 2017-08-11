using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Service.Common;
using TrafficReporter.Repository.Common;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Service
{
    public class ReportService : IReportService
    {
        #region Constructors

        public ReportService(IReportRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Properties

        protected IReportRepository Repository { get; private set; }

        #endregion Properties 

        #region Methods

        /// <summary>
        /// Add to report
        /// </summary>
        /// <param name="Id">Report identifier</param>
        /// <returns></returns>
        public bool AddReport(Guid Id)
        {
            if (!Repository.GetAllReports().First(p => p.Id.Equals(Id)).Active)
            {
                throw new ArgumentOutOfRangeException("Active");
            }
            return Repository.AddReport(Id);
        }

        /// <summary>
        /// Gets all available reports
        /// </summary>
        /// <returns></returns>
        public List<IReportPOCO> GetAllAvailableReports()
        {
            return Repository.GetAllReports().Where(p => p.Active).ToList();
        }

        /// <summary>
        /// Removes report
        /// </summary>
        /// <param name="Id">Report identifier</param>
        /// <returns></returns>
        public bool RemoveReport(Guid Id)
        {
            return Repository.RemoveReport(Id);
        }

        #endregion Methods
    }
}
