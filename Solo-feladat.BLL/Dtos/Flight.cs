﻿using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class Flight
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Airport TakeOfAirport { get; set; }
        public Airport LandingAirport { get; set; }
        public DateTime Date { get; set; }
        public FlightStatus Status { get; set; }
        public TimeSpan Duration { get; set; }

        public ICollection<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
    }
}
