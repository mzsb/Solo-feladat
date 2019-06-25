﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solo_feladat.DAL.Context;

namespace Solo_feladat.DAL.Migrations
{
    [DbContext(typeof(SoloContext))]
    [Migration("20190625120115_datamodel_0")]
    partial class datamodel_0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Solo_feladat.Model.Models.Administrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Airport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("LatitudeCoord");

                    b.Property<float>("LongitudeCoord");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.AirportFlight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AirportId");

                    b.Property<Guid>("FlightId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.HasIndex("FlightId");

                    b.ToTable("AirportFlights");
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Coordinate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FlightId");

                    b.Property<float>("LatitudeCoord");

                    b.Property<float>("LongitudeCoord");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("PilotId");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PilotId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Pilot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Pilots");

                    b.HasData(
                        new
                        {
                            Id = new Guid("927092fc-d835-4438-966d-a232c8a95add"),
                            Name = "teszt"
                        });
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.AirportFlight", b =>
                {
                    b.HasOne("Solo_feladat.Model.Models.Airport", "Airport")
                        .WithMany("AirportFlights")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Solo_feladat.Model.Models.Flight", "Flight")
                        .WithMany("AirportFlights")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Coordinate", b =>
                {
                    b.HasOne("Solo_feladat.Model.Models.Flight", "Flight")
                        .WithMany("Coordinates")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Solo_feladat.Model.Models.Flight", b =>
                {
                    b.HasOne("Solo_feladat.Model.Models.Pilot", "Pilot")
                        .WithMany("Flights")
                        .HasForeignKey("PilotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}