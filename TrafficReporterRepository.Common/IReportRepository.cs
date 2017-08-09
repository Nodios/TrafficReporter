using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporterModels;

namespace TrafficReporterRepository.Common
{
    public interface IReportRepository
    {
        bool AddReport(UserPOCO Korisnik, ReportPOCO Uzrok);
}
}
