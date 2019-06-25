using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Interfaces
{
    public interface IPilotManager
    {
        Task<List<Pilot>> GetPilotsAsync();
        Task<List<Flight>> GetFlightsByPilotIdAsync(Guid PilotId);
    }
}
