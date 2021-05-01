using Microsoft.EntityFrameworkCore.Migrations;

namespace Saponja.Data.Migrations
{
    public partial class Migrationbugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Animals",
                newName: "Specie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specie",
                table: "Animals",
                newName: "Type");
        }
    }
}
