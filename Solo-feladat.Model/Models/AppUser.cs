using Microsoft.AspNetCore.Identity;
using Solo_feladat.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.Model.Models
{
    public class AppUser : IdentityUser<Guid>,IAuditable
    {
        public DateTime CreationDate { get; set; }

        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
        public ICollection<File> Files { get; set; } = new List<File>();
    }
}
