using Solo_feladat.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.Model.Models
{
    public class AirportFlight : IAuditable
    {
        public Guid Id { get; set; }
        public Guid AirportId { get; set; }
        public Airport Airport { get; set; }
        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }
        public DateTime CreationDate { get; set; }

        public AirportType Type { get; set; }
    }
}
