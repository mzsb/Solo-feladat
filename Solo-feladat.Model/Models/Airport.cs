using Solo_feladat.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.Model.Models
{
    public class Airport : IAuditable
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }

        public string  Name { get; set; }
        public Coordinate Coordinate { get; set; }

        public ICollection<AirportFlight> AirportFlights { get; set; } = new List<AirportFlight>();
    }
}
