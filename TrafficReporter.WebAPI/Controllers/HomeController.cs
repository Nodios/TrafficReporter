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


        public ActionResult FilterReports(IEnumerable<IReport> reportCollection = null)
        {
            return View(reportCollection);
        }

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
