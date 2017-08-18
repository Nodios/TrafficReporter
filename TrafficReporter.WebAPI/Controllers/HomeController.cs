using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafficReporter.Model;
using TrafficReporter.Service.Common;
using TrafficReporter.WebAPI.ViewModels;
using AutoMapper;
using TrafficReporter.Model.Common;

namespace TrafficReporter.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        protected IReportService ReportService { get; private set; }
        protected IMapper Mapper { get; set; }

        public HomeController()
        {
            
        }

        public HomeController(IReportService reportService, IMapper mapper)
        {
            ReportService = reportService;
            Mapper = mapper;
        }

        public ActionResult Index(ReportViewModel viewModel = null)
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult Create(ReportViewModel viewModel = null)
        {
            if (ModelState.IsValid)
            {
                ReportService.AddReport(Mapper.Map<IReport>(viewModel));
                return Index(null);
            }

            return View("Index", viewModel);
        }
    }
}
