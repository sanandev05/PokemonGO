using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonGO_Backend.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedPower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttackPower",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttackPower",
                table: "Pokemons");
        }
    }
}
