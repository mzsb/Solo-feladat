using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class Flight
    {
        public Guid Id { get; set; }
        public Guid PilotId { get; set; }
        public Pilot Pilot { get; set; }

        public Airport TakeOfAirport { get; set; }
        public Airport LandingAirport { get; set; }
        public DateTime Date { get; set; }
        public FlightStatus Status { get; set; }
        public ICollection<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
    }
}
