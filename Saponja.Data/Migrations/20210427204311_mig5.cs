using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Saponja.Data.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adopters_Animals_AnimalId",
                table: "Adopters");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalPhotos_Animals_AnimalId",
                table: "AnimalPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Users_ShelterId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ImageLink",
                table: "Posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ContentLink",
                table: "Posts",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "ConfirmationLink",
                table: "Adopters",
                newName: "ConfirmationToken");

            migrationBuilder.AlterColumn<double>(
                name: "Geolocation_Longitude",
                table: "Users",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Geolocation_Latitude",
                table: "Users",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentPath",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "HasBeenApproved",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Animals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Adopters_Animals_AnimalId",
                table: "Adopters",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalPhotos_Animals_AnimalId",
                table: "AnimalPhotos",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Users_ShelterId",
                table: "Animals",
                column: "ShelterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adopters_Animals_AnimalId",
                table: "Adopters");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalPhotos_Animals_AnimalId",
                table: "AnimalPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Users_ShelterId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ContentPath",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "HasBeenApproved",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "ImageLink");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Posts",
                newName: "ContentLink");

            migrationBuilder.RenameColumn(
                name: "ConfirmationToken",
                table: "Adopters",
                newName: "ConfirmationLink");

            migrationBuilder.AlterColumn<float>(
                name: "Geolocation_Longitude",
                table: "Users",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Geolocation_Latitude",
                table: "Users",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adopters_Animals_AnimalId",
                table: "Adopters",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalPhotos_Animals_AnimalId",
                table: "AnimalPhotos",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Users_ShelterId",
                table: "Animals",
                column: "ShelterId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
