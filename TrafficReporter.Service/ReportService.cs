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
using TrafficReporter.Common.Filter;

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

        public Task<IReport> GetReportAsync(Guid id)
        {
            return Repository.GetReportAsync(id);
        }

 
        public Task<int> RemoveReportAsync(Guid id)
        {
            return Repository.RemoveReportAsync(id);
        }




        public Task<IEnumerable<IReport>> GetFilteredReportsAsync(IFilter filter=null)
        {
            return Repository.GetFilteredReportsAsync(filter);
        }

        


        #endregion Methods
    }
}
