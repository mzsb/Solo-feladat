using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solo_feladat.Model.Interfaces;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public DbSet<LogFile> LogFiles { get; set; }
        public DbSet<AirportFile> AirportFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>()
                        .HasOne(a => a.Coordinate)
                        .WithOne(c => c.Airport)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flight>()
                        .HasMany(f => f.Coordinates)
                        .WithOne(c => c.Flight)
                        .OnDelete(DeleteBehavior.Cascade);

            var airportTypeConverter = new EnumToStringConverter<AirportType>();
            modelBuilder.Entity<AirportFlight>()
                        .Property(af => af.Type)
                        .HasConversion(airportTypeConverter);

            var flightStatusConverter = new EnumToStringConverter<FlightStatus>();
            modelBuilder.Entity<Flight>()
                        .Property(f => f.Status)
                        .HasConversion(flightStatusConverter);
        }

        public override int SaveChanges()
        {
            SetCreationDate();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetCreationDate();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetCreationDate();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetCreationDate();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetCreationDate()
        {
            foreach(var e in this.ChangeTracker.Entries<IAuditable>())
            {
                if (e.State.Equals(EntityState.Added))
                {
                    e.Entity.CreationDate = DateTime.Now;
                }
            }
        }
    }
}
