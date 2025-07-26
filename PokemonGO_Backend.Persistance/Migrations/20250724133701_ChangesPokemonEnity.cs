using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonGO_Backend.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangesPokemonEnity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Gyms_GymId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_GymId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Pokemons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Pokemons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_GymId",
                table: "Pokemons",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Gyms_GymId",
                table: "Pokemons",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id");
        }
    }
}
