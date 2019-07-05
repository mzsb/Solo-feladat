using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.Model.Interfaces
{
    public interface IAuditable
    {
        DateTime CreationDate { get; set; }
    }
}
