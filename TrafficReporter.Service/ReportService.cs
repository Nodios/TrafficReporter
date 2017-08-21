using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;
using TrafficReporter.Service.Common;
using TrafficReporter.Repository.Common;
using TrafficReporter.Model;
using TrafficReporter.Common.Enums;
using TrafficReporter.Common;

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

        #endregion Properties 

        #region Methods

       

        public async Task<bool> AddReportAsync(IReport report)
        {
            if (await Repository.AddReportAsync(report) != 1)
                return false;

            return true;
        }

        public async Task<IReport> GetReportAsync(Guid id)
        {
            return await Repository.GetReportAsync(id);
        }

 
        public async Task<int> RemoveReportAsync(Guid id)
        {
            return await Repository.RemoveReportAsync(id);
        }




        public async Task<IEnumerable<IReport>> GetFilteredReportsAsync(CauseFilter causeFilter = null, AreaFilter areaFilter= null)
        {
            return await Repository.GetFilteredReportsAsync(causeFilter, areaFilter);
        }

        


        #endregion Methods
    }
}
