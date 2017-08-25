using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrafficReporter.Model;
using TrafficReporter.Service.Common;
using TrafficReporter.WebAPI.ViewModels;
using AutoMapper;
using Ninject;
using TrafficReporter.Model.Common;
using TrafficReporter.Service;
using System.Net.Http;
using TrafficReporter.Common;
using System.Net;

namespace TrafficReporter.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        
        public HomeController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        public ActionResult Index(ReportViewModel viewModel = null)
        {

            ViewBag.Title = "Home Page";

            return View();
        }


        /// <summary>
        /// Filters the reports.
        /// </summary>
        /// <param name="reportCollection">The report collection.</param>
        /// <returns></returns>
        public ActionResult FilterReports(IEnumerable<IReport> reportCollection = null)
        {
            return View(reportCollection);
        }

        /// <summary>
        /// Creates the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public async Task<ActionResult> Create(ReportViewModel viewModel = null)
        {
            if (ModelState.IsValid)
            {
                await _reportService.AddReportAsync(_mapper.Map<ReportViewModel, IReport>(viewModel));
                return Index(null);
            }

            return View("Index", viewModel);
        }

       
            



    }
}
