using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonGO_Backend.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SomeChangesInRelationinGym : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gyms_Trainers_TrainerId",
                table: "Gyms");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Gyms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Gyms_Trainers_TrainerId",
                table: "Gyms",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gyms_Trainers_TrainerId",
                table: "Gyms");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Gyms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gyms_Trainers_TrainerId",
                table: "Gyms",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
