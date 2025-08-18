using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barber.Migrations
{
    /// <inheritdoc />
    public partial class NewPropScheduling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulings_Users_UserId",
                table: "Schedulings");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateScheduling",
                table: "Schedulings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulings_Users_UserId",
                table: "Schedulings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulings_Users_UserId",
                table: "Schedulings");

            migrationBuilder.DropColumn(
                name: "DateScheduling",
                table: "Schedulings");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulings_Users_UserId",
                table: "Schedulings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
