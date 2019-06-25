using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solo_feladat.DAL.Migrations
{
    public partial class seed_flight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: new Guid("927092fc-d835-4438-966d-a232c8a95add"));

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("03523a6e-0bf9-4fd9-9617-178a38a88454"), "teszt" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Date", "PilotId", "Status" },
                values: new object[] { new Guid("56cbc6da-9296-4268-9f55-d2c1975e00e9"), new DateTime(2019, 6, 25, 16, 48, 37, 35, DateTimeKind.Local).AddTicks(637), new Guid("03523a6e-0bf9-4fd9-9617-178a38a88454"), "Wait" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Pilots",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("927092fc-d835-4438-966d-a232c8a95add"), "teszt" });
        }
    }
}
