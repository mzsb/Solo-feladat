﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.BLL.Dtos
{
    public class Airport
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float LatitudeCoord { get; set; }
        public float LongitudeCoord { get; set; }

    }
}