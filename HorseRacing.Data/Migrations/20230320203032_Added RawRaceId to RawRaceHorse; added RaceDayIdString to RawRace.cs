using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class AddedRawRaceIdtoRawRaceHorseaddedRaceDayIdStringtoRawRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RaceDayIdString",
                table: "RawRace",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RaceDayIdString",
                table: "RaceDay",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaceDayIdString",
                table: "RawRace");

            migrationBuilder.AlterColumn<string>(
                name: "RaceDayIdString",
                table: "RaceDay",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
