using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace erdus.ng.Models
{
    public class Coordinate
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string LatitudeString { get; set; }

        public string LongitudeString { get; set; }

        public Coordinate()
        {
           
        }

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            LatitudeString = Latitude.ToString().Replace(',', '.');
            Longitude = longitude;
            LongitudeString = Longitude.ToString().Replace(',', '.');
        }

        public static bool TryParse(string value, out Coordinate coordinate)
        {
            coordinate = null;
            double latitude;
            double longitude;
            var decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (!value.Contains(",") || value.Count(x => x == ',') > 1)
            {
                return false;
            }

            var splitted = value.Split(',');
            if (!double.TryParse(splitted[0].Replace(".", decimalSeparator).Replace(",", decimalSeparator), out longitude))
            {
                return false;
            }

            if (Math.Abs(longitude) > 180)
            {
                return false;
            }

            if (!double.TryParse(splitted[1].Replace(".", decimalSeparator).Replace(",", decimalSeparator), out latitude))
            {
                return false;
            }

            if (Math.Abs(latitude) > 90)
            {
                return false;
            }

            coordinate = new Coordinate(latitude, longitude);
            return true;
        }
    }
}
