using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class addedRaceDaytoRawRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaceDayId",
                table: "RawRace",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawRace_RaceDayId",
                table: "RawRace",
                column: "RaceDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_RaceDay_RaceDayId",
                table: "RawRace",
                column: "RaceDayId",
                principalTable: "RaceDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_RaceDay_RaceDayId",
                table: "RawRace");

            migrationBuilder.DropIndex(
                name: "IX_RawRace_RaceDayId",
                table: "RawRace");

            migrationBuilder.DropColumn(
                name: "RaceDayId",
                table: "RawRace");
        }
    }
}
