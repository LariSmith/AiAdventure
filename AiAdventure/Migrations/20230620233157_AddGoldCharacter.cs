using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AiAdventure.Migrations
{
    /// <inheritdoc />
    public partial class AddGoldCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gold",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gold",
                table: "Characters");
        }
    }
}
