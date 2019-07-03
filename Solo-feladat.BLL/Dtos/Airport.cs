using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class Airport
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Airport name is required", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Airport's coordinate is required")]
        public Coordinate Coordinate { get; set; }

        public ICollection<AirportFlight> AirportFlights { get; set; } = new List<AirportFlight>();
    }
}
