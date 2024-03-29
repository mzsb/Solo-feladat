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
    [Migration("20190625152541_seed_flight2")]
    partial class seed_flight2
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("906f3f05-ffed-4349-9595-7bf96292b002"),
                            LatitudeCoord = 0.3f,
                            LongitudeCoord = 0.3f,
                            Name = "teszt1"
                        },
                        new
                        {
                            Id = new Guid("4767628d-74d1-4506-9e6e-bdc57a8d624c"),
                            LatitudeCoord = 0.3f,
                            LongitudeCoord = 0.3f,
                            Name = "teszt2"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("0eba1739-9bba-4c27-8c4c-a2480e437e0f"),
                            AirportId = new Guid("906f3f05-ffed-4349-9595-7bf96292b002"),
                            FlightId = new Guid("93eb0f41-53c2-4ad8-9af9-b1c6787143ec"),
                            Type = "Takeoff"
                        },
                        new
                        {
                            Id = new Guid("b7eb8896-d999-434c-a496-797e6a4025f8"),
                            AirportId = new Guid("4767628d-74d1-4506-9e6e-bdc57a8d624c"),
                            FlightId = new Guid("93eb0f41-53c2-4ad8-9af9-b1c6787143ec"),
                            Type = "Takeoff"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("93eb0f41-53c2-4ad8-9af9-b1c6787143ec"),
                            Date = new DateTime(2019, 6, 25, 17, 25, 40, 774, DateTimeKind.Local).AddTicks(463),
                            PilotId = new Guid("ff6f3109-8c7e-4df0-b04d-6ed77d43dbf9"),
                            Status = "Wait"
                        });
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
                            Id = new Guid("ff6f3109-8c7e-4df0-b04d-6ed77d43dbf9"),
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
