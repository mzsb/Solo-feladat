using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class AirportFile
    {
        public Guid Id { get; set; }
        public byte[] File { get; set; }
    }
}
