using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solo_feladat.DAL.Migrations
{
    public partial class seed_flight3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Airports",
                columns: new[] { "Id", "LatitudeCoord", "LongitudeCoord", "Name" },
                values: new object[] { new Guid("c3de7922-e59d-4ac8-b7a8-cb634778a3cf"), 0.3f, 0.3f, "teszt1" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "LatitudeCoord", "LongitudeCoord", "Name" },
                values: new object[] { new Guid("83106795-8ba0-47ab-a610-fdd2ac67aaac"), 0.3f, 0.3f, "teszt2" });

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("95b9c047-84de-4cc8-b193-c985fb8bdf6b"), "teszt" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Date", "PilotId", "Status" },
                values: new object[] { new Guid("ab250dce-6f80-41dc-902b-26cfb0029bd7"), new DateTime(2019, 6, 25, 17, 26, 57, 726, DateTimeKind.Local).AddTicks(8015), new Guid("95b9c047-84de-4cc8-b193-c985fb8bdf6b"), "Wait" });

            migrationBuilder.InsertData(
                table: "AirportFlights",
                columns: new[] { "Id", "AirportId", "FlightId", "Type" },
                values: new object[] { new Guid("cc894fcc-06a0-480e-84ed-1abd101eb24d"), new Guid("c3de7922-e59d-4ac8-b7a8-cb634778a3cf"), new Guid("ab250dce-6f80-41dc-902b-26cfb0029bd7"), "Landing" });

            migrationBuilder.InsertData(
                table: "AirportFlights",
                columns: new[] { "Id", "AirportId", "FlightId", "Type" },
                values: new object[] { new Guid("9e419297-d5bd-43c4-b01f-07657b299e1b"), new Guid("83106795-8ba0-47ab-a610-fdd2ac67aaac"), new Guid("ab250dce-6f80-41dc-902b-26cfb0029bd7"), "Takeoff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AirportFlights",
                keyColumn: "Id",
                keyValue: new Guid("9e419297-d5bd-43c4-b01f-07657b299e1b"));

            migrationBuilder.DeleteData(
                table: "AirportFlights",
                keyColumn: "Id",
                keyValue: new Guid("cc894fcc-06a0-480e-84ed-1abd101eb24d"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: new Guid("83106795-8ba0-47ab-a610-fdd2ac67aaac"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: new Guid("c3de7922-e59d-4ac8-b7a8-cb634778a3cf"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("ab250dce-6f80-41dc-902b-26cfb0029bd7"));

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: new Guid("95b9c047-84de-4cc8-b193-c985fb8bdf6b"));

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
    }
}
