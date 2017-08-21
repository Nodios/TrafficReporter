using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrafficReporter.Model.Common;
using TrafficReporter.Service.Common;
using System.Threading.Tasks;
using Ninject;

namespace TrafficReporter.WebAPI.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        protected IReportService Service { get; private set; }

        [Inject]
        public ReportController(IReportService service)
        {
            Service = service;
        }


        [HttpPost]
        public async Task<bool> AddReportAsync(IReport report)
        {
            return await this.Service.AddReportAsync(report);
        }




        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<int> RemoveReportAsync(Guid id)
        {
            return await this.Service.RemoveReportAsync(id);
        }



        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IReport> GetreportAsync(Guid id)
        {
            return await this.Service.GetReportAsync(id);
        }

    }
}
