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
using TrafficReporter.WebAPI.ViewModels;
using TrafficReporter.Common.Enums;

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

        

        


        [HttpPost]
        public async Task<bool> AddReportAsync(ReportViewModel report)
        {
            return await this._reportService.AddReportAsync(_mapper.Map<IReport>(report));
        }




        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<int> RemoveReportAsync(Guid id)
        {
            return await this._reportService.RemoveReportAsync(id);
        }



        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IReport> GetreportAsync(Guid id)
        {
            return await this._reportService.GetReportAsync(id);
        }


        [HttpGet]
        public async Task<IEnumerable<IReport>> GetFilteredReportsAsync(double dx, double dy, double ux, double uy, string cause, int pageNumber=1, int pageSize=10)
        {

            Filters f = new Filters(dx, dy, ux, uy, cause, pageNumber, pageSize);


            var result = await _reportService.GetFilteredReportsAsync(f);

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
