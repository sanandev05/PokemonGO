using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonGO_Backend.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class XP_ADDEDTOTrainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentXP",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxXP",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentXP",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "MaxXP",
                table: "Trainers");
        }
    }
}
