using Microsoft.EntityFrameworkCore.Migrations;

namespace Solo_feladat.DAL.Migrations
{
    public partial class Flight_Coordinate_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Flights_FlightId",
                table: "Coordinates");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Flights_FlightId",
                table: "Coordinates",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Flights_FlightId",
                table: "Coordinates");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Flights_FlightId",
                table: "Coordinates",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
