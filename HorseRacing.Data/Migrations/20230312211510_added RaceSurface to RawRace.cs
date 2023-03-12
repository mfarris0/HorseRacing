using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class addedRaceSurfacetoRawRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RaceSurfaceId",
                table: "RawRace",
                type: "nvarchar(1)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawRace_RaceSurfaceId",
                table: "RawRace",
                column: "RaceSurfaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_RaceSurface_RaceSurfaceId",
                table: "RawRace",
                column: "RaceSurfaceId",
                principalTable: "RaceSurface",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_RaceSurface_RaceSurfaceId",
                table: "RawRace");

            migrationBuilder.DropIndex(
                name: "IX_RawRace_RaceSurfaceId",
                table: "RawRace");

            migrationBuilder.DropColumn(
                name: "RaceSurfaceId",
                table: "RawRace");
        }
    }
}
