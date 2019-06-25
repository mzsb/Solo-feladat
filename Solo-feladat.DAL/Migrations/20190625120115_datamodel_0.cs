using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solo_feladat.DAL.Migrations
{
    public partial class datamodel_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: new Guid("2381a263-92d8-43dc-850e-9cfeea21c0f0"));

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LatitudeCoord = table.Column<float>(nullable: false),
                    LongitudeCoord = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PilotId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirportFlights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    AirportId = table.Column<Guid>(nullable: false),
                    FlightId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirportFlights_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirportFlights_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FlightId = table.Column<Guid>(nullable: false),
                    LatitudeCoord = table.Column<float>(nullable: false),
                    LongitudeCoord = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinates_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("927092fc-d835-4438-966d-a232c8a95add"), "teszt" });

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlights_AirportId",
                table: "AirportFlights",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlights_FlightId",
                table: "AirportFlights",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_FlightId",
                table: "Coordinates",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PilotId",
                table: "Flights",
                column: "PilotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "AirportFlights");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: new Guid("927092fc-d835-4438-966d-a232c8a95add"));

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2381a263-92d8-43dc-850e-9cfeea21c0f0"), "teszt" });
        }
    }
}
