using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class addedRaceHorseListtoRawRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawRaceHorse_RawRace_RawRaceId",
                table: "RawRaceHorse");

            migrationBuilder.AlterColumn<string>(
                name: "RawRaceId",
                table: "RawRaceHorse",
                type: "nvarchar(13)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RawRaceHorse_RawRace_RawRaceId",
                table: "RawRaceHorse",
                column: "RawRaceId",
                principalTable: "RawRace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawRaceHorse_RawRace_RawRaceId",
                table: "RawRaceHorse");

            migrationBuilder.AlterColumn<string>(
                name: "RawRaceId",
                table: "RawRaceHorse",
                type: "nvarchar(13)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)");

            migrationBuilder.AddForeignKey(
                name: "FK_RawRaceHorse_RawRace_RawRaceId",
                table: "RawRaceHorse",
                column: "RawRaceId",
                principalTable: "RawRace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
