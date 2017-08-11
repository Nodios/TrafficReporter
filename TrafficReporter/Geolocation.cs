using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter
{
    public class Geolocation
    {
        public double Longitude {
            get { return Longitude; }
            set
            {
                if (value > 44 && value < 47)
                {
                    throw new ArgumentOutOfRangeException("Longitude", "Argument must be in range of 44 to 47");
                }
                Longitude = value;
            }
        }
        public double Latitude {
            get { return Latitude; }
            set
            {
                if (value > 12 && value < 20)
                {
                    throw new ArgumentOutOfRangeException("Latitude", "Argument must be in range of 12 to 20");
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
