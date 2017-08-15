using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafficReporter.DAL.Entity_Models;
using TrafficReporter.Service.Common;
using TrafficReporter.Model.Common;


namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private IReportService _reportService;

        public HomeController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddReport(IReport report)
        {
            _reportService.AddReport(report);

            return A

        }
    }
}