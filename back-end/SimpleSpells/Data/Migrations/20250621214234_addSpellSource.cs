using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleSpells.Migrations
{
    /// <inheritdoc />
    public partial class addSpellSource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AEO",
                table: "Spells",
                newName: "AOE");

            migrationBuilder.AddColumn<int[]>(
                name: "Availability",
                table: "Spells",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Spells");

            migrationBuilder.RenameColumn(
                name: "AOE",
                table: "Spells",
                newName: "AEO");
        }
    }
}
