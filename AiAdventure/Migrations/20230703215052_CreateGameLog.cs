using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AiAdventure.Migrations
{
    /// <inheritdoc />
    public partial class CreateGameLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Json",
                table: "turns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Json",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "gameLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gameLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gameLogs_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gameLogs_CharacterId",
                table: "gameLogs",
                column: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gameLogs");

            migrationBuilder.DropColumn(
                name: "Json",
                table: "turns");

            migrationBuilder.DropColumn(
                name: "Json",
                table: "Characters");
        }
    }
}
