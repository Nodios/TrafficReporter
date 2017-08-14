using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter
{
    public class Geolocation
    {
        public double Longitude
        {
            get { return Longitude; }
            set
            {
                if (value > -180 || value < 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude", "Argument must be in range of -180 to 180");
                }
                Longitude = value;
            }
        }
        public double Latitude
        {
            get { return Latitude; }
            set
            {
                if (value > -90 || value < 90)
                {
                    throw new ArgumentOutOfRangeException("Latitude", "Argument must be in range of -90 to 90");
                }
                Latitude = value;
            }
        }
        public bool Equals(Geolocation other)
        {
            if (ReferenceEquals(other, null))
                return false;

            var num = Latitude;

            if (!num.Equals(other.Latitude))
                return false;

            num = Longitude;

            return num.Equals(other.Longitude);
        }
        public static bool operator ==(Geolocation left, Geolocation right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);

            return left.Equals(right);
        }
        public static bool operator !=(Geolocation left, Geolocation right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Geolocation);
        }
    }

}
