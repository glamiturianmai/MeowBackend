using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeowBackend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class HashPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "persons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                table: "persons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password_salt",
                table: "persons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                table: "dogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password_salt",
                table: "dogs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "dogs");

            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "dogs");
        }
    }
}
