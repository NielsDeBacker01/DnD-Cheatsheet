using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleSpells.Migrations
{
    /// <inheritdoc />
    public partial class spellConAndAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Action",
                table: "Spells",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Concentration",
                table: "Spells",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Concentration",
                table: "Spells");
        }
    }
}
