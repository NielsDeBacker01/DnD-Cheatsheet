using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleSpells.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterAndSpellValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AEO",
                table: "Spells",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Effect",
                table: "Spells",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Hitcheck",
                table: "Spells",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Range",
                table: "Spells",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "Spells",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SpellLevel",
                table: "Spells",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Targets",
                table: "Spells",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Upcast",
                table: "Spells",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Spells",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vsm",
                table: "Spells",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AEO",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Effect",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Hitcheck",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Range",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "SpellLevel",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Targets",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Upcast",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Vsm",
                table: "Spells");
        }
    }
}
