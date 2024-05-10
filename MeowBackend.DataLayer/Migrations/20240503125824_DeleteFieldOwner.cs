using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeowBackend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFieldOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cats_persons_owner_id",
                table: "cats");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cats_persons_owner_id",
                table: "cats");

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
    }
}
