using Microsoft.EntityFrameworkCore.Migrations;

namespace Solo_feladat.DAL.Migrations
{
    public partial class Airport_Coordinate_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Airports_AirportId",
                table: "Coordinates");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Airports_AirportId",
                table: "Coordinates",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Airports_AirportId",
                table: "Coordinates");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Airports_AirportId",
                table: "Coordinates",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
