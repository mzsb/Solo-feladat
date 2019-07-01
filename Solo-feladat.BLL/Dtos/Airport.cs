using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class Airport
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public Coordinate Coordinate { get; set; }

        public ICollection<AirportFlight> AirportFlights { get; set; } = new List<AirportFlight>();
    }
}
