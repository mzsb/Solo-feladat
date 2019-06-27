using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Interfaces
{
    public interface IFlightManager
    {
        Task<Flight> GetFlightByIdAsync(Guid Id);
        Task<List<Flight>> GetFlightsByUserIdAsync(Guid UserId);
        Task UpdateFlightAsync(Flight flight);
        Task<List<Flight>> GetFlightsByStatusAsync(FlightStatus status);
    }
}
