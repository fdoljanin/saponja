using Microsoft.EntityFrameworkCore.Migrations;

namespace Saponja.Data.Migrations
{
    public partial class update_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Adopters");

            migrationBuilder.DropColumn(
                name: "LocationAddress",
                table: "Adopters");

            migrationBuilder.RenameColumn(
                name: "Oib",
                table: "Users",
                newName: "WebsiteUrl");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Users",
                newName: "DocumentationFileLink");

            migrationBuilder.RenameColumn(
                name: "DocumentationLink",
                table: "Users",
                newName: "DescriptionFileLink");

            migrationBuilder.RenameColumn(
                name: "IsSterelised",
                table: "Animals",
                newName: "IsSterilized");

            migrationBuilder.RenameColumn(
                name: "DescriptionLink",
                table: "Animals",
                newName: "DescriptionFileLink");

            migrationBuilder.RenameColumn(
                name: "Oib",
                table: "Adopters",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasReceivedDocumentation",
                table: "Adopters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HasReceivedDocumentation",
                table: "Adopters");

            migrationBuilder.RenameColumn(
                name: "WebsiteUrl",
                table: "Users",
                newName: "Oib");

            migrationBuilder.RenameColumn(
                name: "DocumentationFileLink",
                table: "Users",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "DescriptionFileLink",
                table: "Users",
                newName: "DocumentationLink");

            migrationBuilder.RenameColumn(
                name: "IsSterilized",
                table: "Animals",
                newName: "IsSterelised");

            migrationBuilder.RenameColumn(
                name: "DescriptionFileLink",
                table: "Animals",
                newName: "DescriptionLink");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Adopters",
                newName: "Oib");

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Adopters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationAddress",
                table: "Adopters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
