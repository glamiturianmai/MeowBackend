using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeowBackend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class DogDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cats_persons_owner_id",
                table: "cats");

            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "dogs");

            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "dogs");

            migrationBuilder.AlterColumn<Guid>(
                name: "owner_id",
                table: "cats",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_cats_persons_owner_id",
                table: "cats",
                column: "owner_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cats_persons_owner_id",
                table: "cats");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "owner_id",
                table: "cats",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_cats_persons_owner_id",
                table: "cats",
                column: "owner_id",
                principalTable: "persons",
                principalColumn: "id");
        }
    }
}
