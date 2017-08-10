using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporterService.Common;

namespace TrafficReporterModels
{
    public class UserPOCO:IReportService
    {
        Guid Id { get; set; }
        public string ImePrezime { get; set; }
        public string Brmobitela { get; set; }

        public bool AddReport()
        {
            return false;
        }
    }
}
