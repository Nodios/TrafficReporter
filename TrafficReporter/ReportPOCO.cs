using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Common;
using TrafficReporter.Service.Common;
using TrafficReporter.Model.Common;

namespace TrafficReporter
{
    public class ReportPOCO : IReportService
    {
        public Guid Id { get; set; }
        CauseEnum Cause { get; set; }
        public DateTime DateCreated { get; set; }
        public int RatingPlus { get; set; }
        public int RatingMinus { get; set; }
        DirectionEnum Direction { get; set; }
        public Guid UserId { get; set; }
        public bool Active { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        VehicleTypeEnum VehicleType { get; set; }

        public static bool GetAllReport()
        {
            throw new NotImplementedException();
        }

        public bool AddReport(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<IReportPOCO> GetAllAvailableReports()
        {
            throw new NotImplementedException();
        }

        public bool RemoveReport(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}

