using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class File
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }

        public FileType Type { get; set; }
        public byte[] Data { get; set; }
    }
}
