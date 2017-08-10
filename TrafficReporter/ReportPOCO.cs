using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Common;
using TrafficReporter.Service.Common;

namespace TrafficReporter
{
    public class ReportPOCO : IReportService
    {
        private Service.ReportService reportService;

        public ReportPOCO(Service.ReportService reportService)
        {
            this.reportService = reportService;
        }

        public Guid Id { get; set; }
        CauseEnum Cause { get; set; }
        public DateTime DateCreated { get; set; }
        public int RatingPlus { get; set; }
        public int RatingMinus { get; set; }
        DirectionEnum Direction { get; set; }
        public Guid UserId { get; set; }

        public static bool GetAllReport()
        {
            throw new NotImplementedException();
        }

        float Latitude { get; set; }
        float Longitude { get; set; }
        VehicleTypeEnum VehicleType { get; set; }

        public bool AddReport()
        {
            throw new NotImplementedException();
        }
    }
}

