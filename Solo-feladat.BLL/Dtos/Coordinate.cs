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
        public float LatitudeCoord { get; set; }
        public float LongitudeCoord { get; set; }
    }
}
