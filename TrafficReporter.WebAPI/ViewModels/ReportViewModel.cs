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
        public int Cause { get; set; }

        [Required]
        public Direction Direction { get; set; }

        [Required]
        [Range(-180, 180,ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Longitude { get; set; }        

        [Required]
        [Range(-90, 90, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Lattitude { get; set; }

    }
}