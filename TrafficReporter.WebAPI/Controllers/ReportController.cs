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






        /// <summary>
        /// Adds the report asynchronous.
        /// </summary>
        /// <param name="report">The report.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> AddReportAsync(ReportViewModel report)
        {
            return await this._reportService.AddReportAsync(_mapper.Map<IReport>(report));
        }




        /// <summary>
        /// Removes the report asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<int> RemoveReportAsync(Guid id)
        {
            return await this._reportService.RemoveReportAsync(id);
        }



        /// <summary>
        /// Getreports the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IReport> GetreportAsync(Guid id)
        {
            return await this._reportService.GetReportAsync(id);
        }


        /// <summary>
        /// Gets the filtered reports asynchronous.
        /// </summary>
        /// <param name="dx">The dx.</param>
        /// <param name="dy">The dy.</param>
        /// <param name="ux">The ux.</param>
        /// <param name="uy">The uy.</param>
        /// <param name="cause">The cause.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
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
