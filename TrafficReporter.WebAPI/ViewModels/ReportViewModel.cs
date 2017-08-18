using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrafficReporter.Common.Enums;

namespace TrafficReporter.WebAPI.ViewModels
{
    public class ReportViewModel
    {
        public Guid Id { get; set; }
        public Cause Cause { get; set; }
        public Direction Direction { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }
        public DateTime DateCreated { get; set; }
    }
}