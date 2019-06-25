using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.Model.Models
{
    public class Airport
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }
        public float LatitudeCoord { get; set; }
        public float LongitudeCoord { get; set; }

        public ICollection<AirportFlight> AirportFlights { get; set; } = new List<AirportFlight>();
    }
}
