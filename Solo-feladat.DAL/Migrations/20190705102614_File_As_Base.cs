using Microsoft.EntityFrameworkCore.Migrations;

namespace Solo_feladat.DAL.Migrations
{
    public partial class File_As_Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Files",
                newName: "Discriminator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Files",
                newName: "Type");
        }
    }
}
