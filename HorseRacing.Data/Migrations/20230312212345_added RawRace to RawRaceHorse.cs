using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class addedRawRacetoRawRaceHorse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RawRaceId",
                table: "RawRaceHorse",
                type: "nvarchar(13)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawRaceHorse_RawRaceId",
                table: "RawRaceHorse",
                column: "RawRaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawRaceHorse_RawRace_RawRaceId",
                table: "RawRaceHorse",
                column: "RawRaceId",
                principalTable: "RawRace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawRaceHorse_RawRace_RawRaceId",
                table: "RawRaceHorse");

            migrationBuilder.DropIndex(
                name: "IX_RawRaceHorse_RawRaceId",
                table: "RawRaceHorse");

            migrationBuilder.DropColumn(
                name: "RawRaceId",
                table: "RawRaceHorse");
        }
    }
}
