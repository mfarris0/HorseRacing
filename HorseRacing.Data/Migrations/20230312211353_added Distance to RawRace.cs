using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class addedDistancetoRawRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DistanceId",
                table: "RawRace",
                type: "nvarchar(6)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawRace_DistanceId",
                table: "RawRace",
                column: "DistanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_Distance_DistanceId",
                table: "RawRace",
                column: "DistanceId",
                principalTable: "Distance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_Distance_DistanceId",
                table: "RawRace");

            migrationBuilder.DropIndex(
                name: "IX_RawRace_DistanceId",
                table: "RawRace");

            migrationBuilder.DropColumn(
                name: "DistanceId",
                table: "RawRace");
        }
    }
}
