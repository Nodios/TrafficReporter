﻿using System;
using TrafficReporter.Common.Enums;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Model
{
    public class ReportPOCO : IReportPOCO
    {
        public Guid Id { get; set; }
        public Cause Cause { get; set; }
        public DateTime DateCreated { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }
        public int Rating { get; set; }
        public Direction Direction { get; set; }
        public Ban Ban { get; set; }
        public Guid UserId { get; set; }
    }
}
