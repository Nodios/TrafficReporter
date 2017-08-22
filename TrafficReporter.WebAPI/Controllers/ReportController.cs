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
using System.Web.Mvc;

namespace TrafficReporter.WebAPI.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;


        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

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


        [HttpGet]
        [Route("api/home/")]
        public async Task<ActionResult> GetFilteredReportsAsync(double dx, double dy, double ux, double uy)
        {

            var result = await _reportService.GetFilteredReportsAsync(new CauseFilter(1, 10, 10), new AreaFilter(dx, dy, ux, uy, 5, 5));

            if (result != null)
            {
                return View("FilterReports", result);
            }
            else
            {
                return View();
            }
        }

        
    }
}
