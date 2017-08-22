﻿using System;
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

        [HttpGet]
        [Route("{dx}/{dy}/{ux}/{uy}")]
        public async Task<ActionResult> GetFilteredReportsAsync()
        {

            var result = await _reportService.GetFilteredReportsAsync(new CauseFilter(0, 10, 10), new AreaFilter(0,0,50,50, 5, 5));
            
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
