using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleSpells.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "SpellIds",
                table: "Characters");

            migrationBuilder.CreateTable(
                name: "CharacterSpell",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    SpellId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSpell", x => new { x.CharacterId, x.SpellId });
                    table.ForeignKey(
                        name: "FK_CharacterSpell_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSpell_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellSourceMapping",
                columns: table => new
                {
                    SpellId = table.Column<int>(type: "integer", nullable: false),
                    Source = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSourceMapping", x => new { x.SpellId, x.Source });
                    table.ForeignKey(
                        name: "FK_SpellSourceMapping_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Level", "Name", "SpellAtkBonus" },
                values: new object[,]
                {
                    { 1, 8, 1, "Aragorn", 7 },
                    { 2, 5, 7, "Sandalphon", 5 },
                    { 3, 3, 20, "Shabar", 12 },
                    { 4, 12, 1, "Gale", 6 }
                });

            migrationBuilder.InsertData(
                table: "Spells",
                columns: new[] { "Id", "AOE", "Action", "Concentration", "Effect", "Hitcheck", "Name", "Range", "Requirements", "SpellLevel", "Targets", "Upcast", "Url", "Vsm" },
                values: new object[,]
                {
                    { 1, "", 1, "", "{base=1D10} force damage", 1, "Eldritch blast{1}", 120, "", 0, "1", "", "https://dnd5e.wikidot.com/spell:eldritch-blast", "V,S" },
                    { 2, "", 1, "", "{base=1D10} force damage", 1, "Eldritch blast{5}", 120, "", 0, "2", "", "https://dnd5e.wikidot.com/spell:eldritch-blast", "V,S" },
                    { 3, "", 1, "", "{base=1D10} force damage", 1, "Eldritch blast{11}", 120, "", 0, "3", "", "https://dnd5e.wikidot.com/spell:eldritch-blast", "V,S" },
                    { 4, "", 1, "", "{base=1D10} force damage", 1, "Eldritch blast{17}", 120, "", 0, "4", "", "https://dnd5e.wikidot.com/spell:eldritch-blast", "V,S" },
                    { 5, "", 1, "", "-Push medium creature 5ft -Push object 10ft", 3, "Gust", 30, "", 0, "1", "", "https://dnd5e.wikidot.com/spell:gust", "V,S" },
                    { 6, "", 1, "1 minute", "d4 attack roll / saving throw bonus", 0, "Bless", 30, "", 1, "3", "1 extra target", "https://dnd5e.wikidot.com/spell:bless", "V,S,M" },
                    { 7, "", 1, "", "{Base: 3D8} acid/cold/fire/lightning/poison/thunder damage", 1, "Chromatic orb", 90, "50 GP diamond", 1, "1", "{Base: 1d8} extra damage", "https://dnd5e.wikidot.com/spell:chromatic-orb", "V,S,M" },
                    { 8, "15ft square", 1, "10 minutes", "Spawn 60ft cloud {Base: 3d10} lightning damage", 4, "Call lightning", 120, "Open sky", 3, "1", "{Base: 1d10} extra damage", "https://dnd5e.wikidot.com/spell:call-lightning", "V,S" },
                    { 9, "40ft square", 1, "1 minute", "Difficult terrain, Darkness, Thunder immunity, Deafened, {Base: 8d10} force damage", 5, "Dark star", 150, "", 8, "", "", "https://dnd5e.wikidot.com/spell:dark-star", "V,S,M" }
                });

            migrationBuilder.InsertData(
                table: "CharacterSpell",
                columns: new[] { "CharacterId", "SpellId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 5 },
                    { 1, 6 },
                    { 2, 2 },
                    { 3, 4 },
                    { 3, 6 },
                    { 3, 8 },
                    { 3, 9 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 }
                });

            migrationBuilder.InsertData(
                table: "SpellSourceMapping",
                columns: new[] { "Source", "SpellId" },
                values: new object[,]
                {
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 3 },
                    { 11, 4 },
                    { 4, 5 },
                    { 10, 5 },
                    { 12, 5 },
                    { 3, 6 },
                    { 10, 6 },
                    { 10, 7 },
                    { 12, 7 },
                    { 4, 8 },
                    { 12, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpell_SpellId",
                table: "CharacterSpell",
                column: "SpellId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSpell");

            migrationBuilder.DropTable(
                name: "SpellSourceMapping");

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AddColumn<int[]>(
                name: "Availability",
                table: "Spells",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<List<int>>(
                name: "SpellIds",
                table: "Characters",
                type: "integer[]",
                nullable: false);
        }
    }
}
