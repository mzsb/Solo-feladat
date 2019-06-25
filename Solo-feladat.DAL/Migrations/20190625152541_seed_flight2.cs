using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solo_feladat.DAL.Migrations
{
    public partial class seed_flight2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("56cbc6da-9296-4268-9f55-d2c1975e00e9"));

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: new Guid("03523a6e-0bf9-4fd9-9617-178a38a88454"));

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "LatitudeCoord", "LongitudeCoord", "Name" },
                values: new object[] { new Guid("906f3f05-ffed-4349-9595-7bf96292b002"), 0.3f, 0.3f, "teszt1" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "LatitudeCoord", "LongitudeCoord", "Name" },
                values: new object[] { new Guid("4767628d-74d1-4506-9e6e-bdc57a8d624c"), 0.3f, 0.3f, "teszt2" });

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ff6f3109-8c7e-4df0-b04d-6ed77d43dbf9"), "teszt" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Date", "PilotId", "Status" },
                values: new object[] { new Guid("93eb0f41-53c2-4ad8-9af9-b1c6787143ec"), new DateTime(2019, 6, 25, 17, 25, 40, 774, DateTimeKind.Local).AddTicks(463), new Guid("ff6f3109-8c7e-4df0-b04d-6ed77d43dbf9"), "Wait" });

            migrationBuilder.InsertData(
                table: "AirportFlights",
                columns: new[] { "Id", "AirportId", "FlightId", "Type" },
                values: new object[] { new Guid("0eba1739-9bba-4c27-8c4c-a2480e437e0f"), new Guid("906f3f05-ffed-4349-9595-7bf96292b002"), new Guid("93eb0f41-53c2-4ad8-9af9-b1c6787143ec"), "Takeoff" });

            migrationBuilder.InsertData(
                table: "AirportFlights",
                columns: new[] { "Id", "AirportId", "FlightId", "Type" },
                values: new object[] { new Guid("b7eb8896-d999-434c-a496-797e6a4025f8"), new Guid("4767628d-74d1-4506-9e6e-bdc57a8d624c"), new Guid("93eb0f41-53c2-4ad8-9af9-b1c6787143ec"), "Takeoff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AirportFlights",
                keyColumn: "Id",
                keyValue: new Guid("0eba1739-9bba-4c27-8c4c-a2480e437e0f"));

            migrationBuilder.DeleteData(
                table: "AirportFlights",
                keyColumn: "Id",
                keyValue: new Guid("b7eb8896-d999-434c-a496-797e6a4025f8"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: new Guid("4767628d-74d1-4506-9e6e-bdc57a8d624c"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: new Guid("906f3f05-ffed-4349-9595-7bf96292b002"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("93eb0f41-53c2-4ad8-9af9-b1c6787143ec"));

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: new Guid("ff6f3109-8c7e-4df0-b04d-6ed77d43dbf9"));

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("03523a6e-0bf9-4fd9-9617-178a38a88454"), "teszt" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Date", "PilotId", "Status" },
                values: new object[] { new Guid("56cbc6da-9296-4268-9f55-d2c1975e00e9"), new DateTime(2019, 6, 25, 16, 48, 37, 35, DateTimeKind.Local).AddTicks(637), new Guid("03523a6e-0bf9-4fd9-9617-178a38a88454"), "Wait" });
        }
    }
}
