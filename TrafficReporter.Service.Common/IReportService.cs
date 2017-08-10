using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporterModels;

namespace TrafficReporterService.Common
{
    public interface IReportService
    {
        bool AddReport(UserPOCO Korisnik, ReportPOCO Uzrok);
    }
}
