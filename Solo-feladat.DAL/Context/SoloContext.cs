using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.DAL.Context
{
    public class SoloContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public SoloContext(DbContextOptions<SoloContext> options) : base(options) { }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<AirportFlight> AirportFlights { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>()
                        .HasOne(a => a.Coordinate)
                        .WithOne(c => c.Airport)
                        .OnDelete(DeleteBehavior.Cascade);

            var airportTypeConverter = new EnumToStringConverter<AirportType>();
            modelBuilder.Entity<AirportFlight>()
                        .Property(af => af.Type)
                        .HasConversion(airportTypeConverter);

            var flightStatusConverter = new EnumToStringConverter<FlightStatus>();
            modelBuilder.Entity<Flight>()
                        .Property(f => f.Status)
                        .HasConversion(flightStatusConverter);

            var fileTypeConverter = new EnumToStringConverter<FileType>();
            modelBuilder.Entity<File>()
                        .Property(f => f.Type)
                        .HasConversion(fileTypeConverter);
        }
    }
}
