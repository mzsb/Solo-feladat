using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Interfaces
{
    public interface IAirportFileManager : IFileManager
    {
        Task ProcessFile();
    }
}
