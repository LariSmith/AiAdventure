using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AiAdventure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSmallChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_turns_TurnId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_TurnId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "TurnId",
                table: "Characters");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                table: "turns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "List",
                table: "Proficiencies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_turns_CharacterId",
                table: "turns",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_turns_Characters_CharacterId",
                table: "turns",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_turns_Characters_CharacterId",
                table: "turns");

            migrationBuilder.DropIndex(
                name: "IX_turns_CharacterId",
                table: "turns");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "turns");

            migrationBuilder.DropColumn(
                name: "Background",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Characters");

            migrationBuilder.AlterColumn<string>(
                name: "List",
                table: "Proficiencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Characters",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "TurnId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Characters_TurnId",
                table: "Characters",
                column: "TurnId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_turns_TurnId",
                table: "Characters",
                column: "TurnId",
                principalTable: "turns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
