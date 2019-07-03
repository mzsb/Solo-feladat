using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.Model.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public FileType Type { get; set; }
        public byte[] Data { get; set; }
        public bool Processed { get; set; } = false;
    }
}
