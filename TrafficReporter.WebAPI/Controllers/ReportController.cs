using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using TrafficReporter.Model.Common;
using TrafficReporter.Service.Common;
using System.Threading.Tasks;
using Ninject;
using AutoMapper;
using TrafficReporter.Common;


//using System.Web.Mvc;
using System.Web.Http;
using TrafficReporter.Common.Filter;

namespace TrafficReporter.WebAPI.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;


        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        protected IReportService Service { get; private set; }

        


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


        [HttpGet]
        [Route("GetFilters")]
        public async Task<IEnumerable<IReport>> GetFilteredReportsAsync()
        {

            var result = await _reportService.GetFilteredReportsAsync();

            if (result != null)
            {
                return result;
            }
            else
            {
                return new List<IReport>();
            }
        }


    }
}
