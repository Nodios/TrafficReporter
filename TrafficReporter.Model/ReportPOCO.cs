using System;
using TrafficReporter.Common.Enums;

namespace TrafficReporter.Model
{
    public class ReportPOCO
    {
        public Guid Id { get; set; }
        public Cause Cause { get; set; }
        public DateTime DateCreated { get; set; }
        public int Rating { get; set; }
        public Direction Direction { get; set; }
        public Ban Ban { get; set; }
    }
}
