using Microsoft.EntityFrameworkCore.Migrations;

namespace Saponja.Data.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentationFileLink",
                table: "Users",
                newName: "DocumentationFilePath");

            migrationBuilder.RenameColumn(
                name: "DescriptionFileLink",
                table: "Users",
                newName: "DescriptionFilePath");

            migrationBuilder.RenameColumn(
                name: "ProfilePhotoLink",
                table: "Animals",
                newName: "ProfilePhotoPath");

            migrationBuilder.RenameColumn(
                name: "DescriptionFileLink",
                table: "Animals",
                newName: "DescriptionFilePath");

            migrationBuilder.RenameColumn(
                name: "PhotoLink",
                table: "AnimalPhotos",
                newName: "PhotoPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentationFilePath",
                table: "Users",
                newName: "DocumentationFileLink");

            migrationBuilder.RenameColumn(
                name: "DescriptionFilePath",
                table: "Users",
                newName: "DescriptionFileLink");

            migrationBuilder.RenameColumn(
                name: "ProfilePhotoPath",
                table: "Animals",
                newName: "ProfilePhotoLink");

            migrationBuilder.RenameColumn(
                name: "DescriptionFilePath",
                table: "Animals",
                newName: "DescriptionFileLink");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "AnimalPhotos",
                newName: "PhotoLink");
        }
    }
}
