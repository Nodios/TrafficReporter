using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Common.Enums;

namespace TrafficReporter.DAL.EntityModels
{
    public class Report
    {
        /// <summary>
        /// Unique indetifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// What is the cause for this report.
        /// </summary>
        public Cause Cause { get; set; }

        /// <summary>
        /// When was this report created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Longitude of geolocation of a report.
        /// </summary>
        public int Longitude { get; set; }

        /// <summary>
        /// Lattitude of geolocation of a report.
        /// </summary>
        public int Lattitude { get; set; }

        /// <summary>
        /// Rating is used to measure report's relevance.
        /// Now it is a single number because plus and minus ratings
        /// won't be suitable for simplistic UI.
        /// </summary>
        public int Rating { get; set; }

    }
}
