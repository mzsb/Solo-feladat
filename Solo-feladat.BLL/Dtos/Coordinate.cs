using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class Coordinate
    {
        public Guid Id { get; set; }
        public Guid FlightId { get; set; }
        public Guid AirportId { get; set; }

        [Required(ErrorMessage = "LatitudeCoord is required")]
        public double LatitudeCoord { get; set; }

        [Required(ErrorMessage = "LongitudeCoord is required")]
        public double LongitudeCoord { get; set; }
    }
}
