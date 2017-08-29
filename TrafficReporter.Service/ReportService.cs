using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;
using TrafficReporter.Service.Common;
using TrafficReporter.Repository.Common;
using TrafficReporter.Common.Filter;
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

        #endregion Properties 

        #region Methods



        /// <summary>
        /// Adds report trough repository method.
        /// Also if something happens during add, this method can throw exception
        /// and methods invoking this can respond to that.
        /// </summary>
        /// <param name="report"></param>
        /// <returns>
        /// True or false depending on operation success.
        /// </returns>
        public async Task<Inserted> AddReportAsync(IReport report)
        {
            report.Id = Guid.NewGuid();
            if (await Repository.AddReportAsync(report) != 1)
                return Inserted.Updated;

            return Inserted.Added;
        }

        /// <summary>
        /// Gets report trough repository from database.
        /// </summary>
        /// <param name="id">Identifier which is criteria for searching through database.</param>
        /// <returns>
        /// Report with the given id.
        /// </returns>
        public Task<IReport> GetReportAsync(Guid id)
        {
            return Repository.GetReportAsync(id);
        }


        /// <summary>
        /// Removes report from database trough repository method.
        /// </summary>
        /// <param name="id">Report identifier.</param>
        /// <returns>
        /// True or false depending on operation success.
        /// </returns>
        public Task<int> RemoveReportAsync(Guid id)
        {
            return Repository.RemoveReportAsync(id);
        }




        /// <summary>
        /// Gets the filtered reports asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public Task<IEnumerable<IReport>> GetFilteredReportsAsync(IFilter filter=null)
        {
            return Repository.GetFilteredReportsAsync(filter);
        }

        


        #endregion Methods
    }
}
