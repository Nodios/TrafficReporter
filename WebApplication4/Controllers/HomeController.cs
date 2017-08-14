using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafficReporter.DAL.Entity_Models;
using TrafficReporter.Service.Common;


namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private IReportService ReportService;

        public HomeController(IReportService reportService)
        {
            ReportService = reportService;
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
            ReportService.AddReport()
        }
    }
}