using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class File
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }

        [Required(ErrorMessage = "Data is required")]
        public byte[] Data { get; set; }
    }
}
