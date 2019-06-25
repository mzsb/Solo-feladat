using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.DAL.Context
{
    public class SoloContext : DbContext
    {
        public SoloContext(DbContextOptions<SoloContext> options) : base(options) { }

        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<AirportFlight> AirportFlights { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Guid userId = Guid.NewGuid();
            Guid flightId = Guid.NewGuid();
            Guid airportId1 = Guid.NewGuid();
            Guid airportId2 = Guid.NewGuid();

            modelBuilder.Entity<Pilot>().HasData(
            new Pilot
            {
                Id = userId,
                Name = "teszt"
            });

            modelBuilder.Entity<Flight>().HasData(
            new Flight
            {
                Id = flightId,
                PilotId = userId,
                Date = DateTime.Now,
                Status = FlightStatus.Wait
            });

            modelBuilder.Entity<Airport>().HasData(
            new Airport
            {
                Id = airportId1,
                Name = "teszt1",
                LatitudeCoord = 0.3f,
                LongitudeCoord= 0.3f
            },new Airport
            {
                Id = airportId2,
                Name = "teszt2",
                LatitudeCoord = 0.3f,
                LongitudeCoord = 0.3f
            });

            modelBuilder.Entity<AirportFlight>().HasData(
            new AirportFlight
            {
                Id = Guid.NewGuid(),
                Type = AirportType.Landing,
                FlightId = flightId,
                AirportId = airportId1
            },
            new AirportFlight
            {
                Id = Guid.NewGuid(),
                Type = AirportType.Takeoff,
                FlightId = flightId,
                AirportId = airportId2
            });

            var airportTypeConverter = new EnumToStringConverter<AirportType>();
            modelBuilder.Entity<AirportFlight>()
                        .Property(af => af.Type)
                        .HasConversion(airportTypeConverter);

            var flightStatusConverter = new EnumToStringConverter<FlightStatus>();
            modelBuilder.Entity<Flight>()
                        .Property(f => f.Status)
                        .HasConversion(flightStatusConverter);
        }
    }
}
