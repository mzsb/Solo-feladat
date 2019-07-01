using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class Coordinate
    {
        public Guid Id { get; set; }
        public Guid FlightId { get; set; }
        public Guid AirportId { get; set; }

        public double LatitudeCoord { get; set; }
        public double LongitudeCoord { get; set; }
    }
}
