using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporterService.Common;

namespace TrafficReporterModels
{
    class PicturePOCO:IReportService
    {
        public Guid Id { get; set; }
        public byte[] PicArray { get; set; }

        public bool AddReport()
        {
            return false;
        }
    }
}
