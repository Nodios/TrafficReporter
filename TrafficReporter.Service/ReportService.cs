using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;
using TrafficReporter.Repository.Common;
using TrafficReporter.Service;
using TrafficReporter.Service.Common;

namespace TrafficReporter.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService()
        {
            
        }

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public bool AddReport(IReport report)
        {
            if (_reportRepository.AddReport(report) != 1)
            {
                return false;
            }

            return true;
        }
    }
}
