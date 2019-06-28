using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solo_feladat.DAL.Migrations
{
    public partial class Airport_Coordinate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Flights_FlightId",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "LatitudeCoord",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "LongitudeCoord",
                table: "Airports");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Files",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "FlightId",
                table: "Coordinates",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "AirportId",
                table: "Coordinates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_AppUserId",
                table: "Files",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_AirportId",
                table: "Coordinates",
                column: "AirportId",
                unique: true,
                filter: "[AirportId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Airports_AirportId",
                table: "Coordinates",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Flights_FlightId",
                table: "Coordinates",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_AppUserId",
                table: "Files",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Airports_AirportId",
                table: "Coordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Flights_FlightId",
                table: "Coordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_AspNetUsers_AppUserId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_AppUserId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Coordinates_AirportId",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Coordinates");

            migrationBuilder.AlterColumn<Guid>(
                name: "FlightId",
                table: "Coordinates",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "LatitudeCoord",
                table: "Airports",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LongitudeCoord",
                table: "Airports",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Flights_FlightId",
                table: "Coordinates",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
