using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrafficReporter.Model.Common;
using TrafficReporter.Service.Common;

namespace TrafficReporter.WebAPI.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        protected IReportService Service { get; private set; }

        public ReportController(IReportService service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IReport AddReport(Guid id)
        {
            return this.Service.GetReport(id);
        }
        
    }
}
