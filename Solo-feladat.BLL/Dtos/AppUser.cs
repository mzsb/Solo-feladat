using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class AppUser
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}
