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

        public bool AddReport(ReportPOCO Uzrok)
        {
            if (!ReportPOCO.GetAllReport().(p => p.Id.Equals(Uzrok)).Cause)
            {
                throw new NotImplementedException();
            }
            return Repository.AddReport(Uzrok);
        }



        #endregion Methods
    }
}
