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

       

        public bool AddReport(IReport report)
        {
            if (Repository.AddReport(report) != 1)
                return false;

            return true;
        }

        public IReport GetReport(Guid id)
        {
            return Repository.GetReport(id);
        }

 
        public bool RemoveReport(Guid id)
        {
            throw new NotImplementedException();
        }



        IReport IReportService.GetReport(Guid id)
        {
            return this.Repository.GetReport(id);
        }

        #endregion Methods
    }
}
