using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class Flight
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [Required(ErrorMessage = "TakeOfAirport is required")]
        public Airport TakeOfAirport { get; set; }

        [Required(ErrorMessage = "LandingAirport is required")]
        public Airport LandingAirport { get; set; }

        [Required(ErrorMessage = "Flight's date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Flight's status is required")]
        public FlightStatus Status { get; set; }

        [Required(ErrorMessage = "Flight's duration is required")]
        public TimeSpan Duration { get; set; }

        public ICollection<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
    }
}
