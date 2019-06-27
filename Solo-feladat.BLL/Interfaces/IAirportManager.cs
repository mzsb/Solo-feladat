using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Interfaces
{
    public interface IAirportManager
    {
        Task InsertAirportAsync(Airport airport);
        Task InsertAirportFilesAsync(List<AirportFile> airportFile);
    }
}
