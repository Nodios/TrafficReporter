using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TrafficReporter.Model.Common;
using TrafficReporter.Service;
using TrafficReporter.Service.Common;

namespace TrafficReporter.WebAPI.Controllers
{
    [RoutePrefix("api/causes")]
    public class CausesController : ApiController
    {
        private readonly ICauseService _causeService;

        public CausesController(ICauseService causeService)
        {
            _causeService = causeService;
        }

        /// <summary>
        /// This API method is used for getting causes and needed data(such as icons)
        /// for angular app startup.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<ICause>> GetCauses()
        {
            return _causeService.GetCausesAsync();
        }
    }
}
