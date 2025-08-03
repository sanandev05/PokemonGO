using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonGO_Backend.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class entities_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accuracy",
                table: "PokemonAbilities");

            migrationBuilder.DropColumn(
                name: "Damage",
                table: "PokemonAbilities");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "PokemonCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "PokemonCategories");

            migrationBuilder.AddColumn<decimal>(
                name: "Accuracy",
                table: "PokemonAbilities",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Damage",
                table: "PokemonAbilities",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
