using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AiAdventure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creatures_Locations_OriginalLocationId",
                table: "Creatures");

            migrationBuilder.DropForeignKey(
                name: "FK_NPCs_Locations_OriginalLocationId",
                table: "NPCs");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Locations_OriginalLocationId",
                table: "Quests");

            migrationBuilder.DropForeignKey(
                name: "FK_treasures_Locations_OriginalLocationId",
                table: "treasures");

            migrationBuilder.DropIndex(
                name: "IX_treasures_OriginalLocationId",
                table: "treasures");

            migrationBuilder.DropIndex(
                name: "IX_NPCs_OriginalLocationId",
                table: "NPCs");

            migrationBuilder.DropIndex(
                name: "IX_Creatures_OriginalLocationId",
                table: "Creatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quests",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Quests_OriginalLocationId",
                table: "Quests");

            migrationBuilder.RenameTable(
                name: "Quests",
                newName: "Quests");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "treasures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "NPCs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Creatures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Quests",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quests",
                table: "Quests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_treasures_LocationId",
                table: "treasures",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_NPCs_LocationId",
                table: "NPCs",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_LocationId",
                table: "Creatures",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_LocationId",
                table: "Quests",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Creatures_Locations_LocationId",
                table: "Creatures",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NPCs_Locations_LocationId",
                table: "NPCs",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Locations_LocationId",
                table: "Quests",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_treasures_Locations_LocationId",
                table: "treasures",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creatures_Locations_LocationId",
                table: "Creatures");

            migrationBuilder.DropForeignKey(
                name: "FK_NPCs_Locations_LocationId",
                table: "NPCs");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Locations_LocationId",
                table: "Quests");

            migrationBuilder.DropForeignKey(
                name: "FK_treasures_Locations_LocationId",
                table: "treasures");

            migrationBuilder.DropIndex(
                name: "IX_treasures_LocationId",
                table: "treasures");

            migrationBuilder.DropIndex(
                name: "IX_NPCs_LocationId",
                table: "NPCs");

            migrationBuilder.DropIndex(
                name: "IX_Creatures_LocationId",
                table: "Creatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quests",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Quests_LocationId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "treasures");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "NPCs");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Creatures");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Quests");

            migrationBuilder.RenameTable(
                name: "Quests",
                newName: "Quests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quests",
                table: "Quests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_treasures_OriginalLocationId",
                table: "treasures",
                column: "OriginalLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_NPCs_OriginalLocationId",
                table: "NPCs",
                column: "OriginalLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_OriginalLocationId",
                table: "Creatures",
                column: "OriginalLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_OriginalLocationId",
                table: "Quests",
                column: "OriginalLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Creatures_Locations_OriginalLocationId",
                table: "Creatures",
                column: "OriginalLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NPCs_Locations_OriginalLocationId",
                table: "NPCs",
                column: "OriginalLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Locations_OriginalLocationId",
                table: "Quests",
                column: "OriginalLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_treasures_Locations_OriginalLocationId",
                table: "treasures",
                column: "OriginalLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
