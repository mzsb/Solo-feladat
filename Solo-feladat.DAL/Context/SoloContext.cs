using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pilot>().HasData(
            new Pilot
            {
                Id = Guid.NewGuid(),
                Name = "teszt"
            });
        }
    }
}
