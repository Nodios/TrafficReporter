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

            return View(viewModel);
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
        
        public async Task<ActionResult> Get()
        {
            Guid asd = new Guid("14045067-8241-4b33-9649-f8523796c19f");
            if (ModelState.IsValid)
            {
                IReport result = await _reportService.GetReportAsync(asd);

                return View("Index", _mapper.Map<ReportViewModel>(result));
            }

            return View("Index");

        }
    }
}
