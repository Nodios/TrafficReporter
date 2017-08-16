using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrafficReporter.DAL.Entity_Models;
using TrafficReporter.Model.Common;
using TrafficReporter.Service.Common;

namespace WebApplication4.Controllers
{
    public class ReportController : ApiController
    {
        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="ReportController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public ReportController(IReportService service)
        {
            this.Service = service;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <value>The service.</value>
        protected IReportService Service { get; private set; }

        #endregion Properties

        #region Methods

        [HttpDelete]
        public bool DeleteReportAsync(Guid Id)
        {
            return Service.RemoveReport(Id);
        }

        [HttpGet]
        public List<Report> GetAsync()
        {
            List<Report> a = null;
            return a;
        }

        [HttpGet]
        public IReportPOCO GetReportAsync()
        {
            IReportPOCO c = null;
            return c;
        }


        [HttpGet]

        public Report GetCauseAsync(double x1, double y1, double x2, double y2)
        {
            Report a = null;
            return a;
        }


        #endregion Methods
    }
}
