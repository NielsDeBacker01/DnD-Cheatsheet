using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleSpells.Migrations
{
    /// <inheritdoc />
    public partial class IdsInsteadOffDirectLinksForSpells : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spells_Characters_CharacterId",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Spells_CharacterId",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Spells");

            migrationBuilder.AddColumn<List<int>>(
                name: "SpellIds",
                table: "Characters",
                type: "integer[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpellIds",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Spells",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spells_CharacterId",
                table: "Spells",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_Characters_CharacterId",
                table: "Spells",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
