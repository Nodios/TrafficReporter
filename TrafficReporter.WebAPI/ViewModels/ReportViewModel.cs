using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrafficReporter.Common.Enums;

namespace TrafficReporter.WebAPI.ViewModels
{
    public class ReportViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public Cause Cause { get; set; }

        [Required]
        public Direction Direction { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Lattitude { get; set; }

    }
}