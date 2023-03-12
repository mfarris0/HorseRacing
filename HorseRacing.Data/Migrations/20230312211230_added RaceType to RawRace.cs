using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class addedRaceTypetoRawRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RaceTypeId",
                table: "RawRace",
                type: "nvarchar(2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawRace_RaceTypeId",
                table: "RawRace",
                column: "RaceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_RaceType_RaceTypeId",
                table: "RawRace",
                column: "RaceTypeId",
                principalTable: "RaceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_RaceType_RaceTypeId",
                table: "RawRace");

            migrationBuilder.DropIndex(
                name: "IX_RawRace_RaceTypeId",
                table: "RawRace");

            migrationBuilder.DropColumn(
                name: "RaceTypeId",
                table: "RawRace");
        }
    }
}
