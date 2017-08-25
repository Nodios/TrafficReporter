using System;
using TrafficReporter.Common.Enums;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Model
{
    public class Report : IReport
    {


        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the cause.
        /// </summary>
        /// <value>
        /// The cause.
        /// </value>
        public int Cause { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public int Rating { get; set; }
        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        public Direction Direction { get; set; }


        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">Longitude - Argument must be in range of -180 to 180</exception>


        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude", "Argument must be in range of -180 to 180");
                }
                else
                {
                    _longitude = value;
                }
            }
        }


        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">Latitude - Argument must be in range of -90 to 90</exception>
        private double _lattitude;

        public double Lattitude
        {
            get { return _lattitude; }
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("Lattitude", "Argument must be in range of -90 to 90");
                }
                else
                {
                    _lattitude = value;
                }
            }
        }
    }
}
