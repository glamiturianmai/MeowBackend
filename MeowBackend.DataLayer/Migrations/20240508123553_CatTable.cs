using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeowBackend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class CatTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "cats");

            migrationBuilder.DropColumn(
                name: "email",
                table: "cats");

            migrationBuilder.DropColumn(
                name: "password",
                table: "cats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "cats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "cats",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "cats",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
