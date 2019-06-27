using Microsoft.EntityFrameworkCore;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.DAL.Context;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Managers
{
    public class FlightManager : IFlightManager
    {
        private readonly SoloContext context;

        public FlightManager(SoloContext context)
        {
            this.context = context;
        }

        public async Task<Flight> GetFlightByIdAsync(Guid Id)
        {
            return await context.Flights.Include(f => f.AirportFlights)
                                        .ThenInclude(af => af.Airport)
                                        .Include(f => f.AppUser)
                                        .Where(f => f.Id.Equals(Id))
                                        .AsNoTracking()
                                        .SingleOrDefaultAsync();
        }

        public async Task<List<Flight>> GetFlightsByStatusAsync(FlightStatus status)
        {
            return await context.Flights.Include(f => f.AirportFlights)
                                        .ThenInclude(af => af.Airport)
                                        .Include(f => f.AppUser)
                                        .Where(f => f.Status.Equals(status))
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        public async Task<List<Flight>> GetFlightsByUserIdAsync(Guid UserId)
        {
            return await context.Flights.Include(f => f.AirportFlights)
                                        .ThenInclude(af => af.Airport)
                                        .Where(f => f.AppUserId.Equals(UserId))
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            context.Attach(flight).State = EntityState.Modified;

            foreach (var dl in context.AirportFlights.Where(af => af.FlightId.Equals(flight.Id)))
            {
                context.AirportFlights.Remove(dl);
            }

            await context.SaveChangesAsync();
        }
    }
}
