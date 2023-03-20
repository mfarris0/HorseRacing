using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class AddedTrackIdtoRaceDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceDay_Track_TrackId",
                table: "RaceDay");

            migrationBuilder.AlterColumn<string>(
                name: "TrackId",
                table: "RaceDay",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceDay_Track_TrackId",
                table: "RaceDay",
                column: "TrackId",
                principalTable: "Track",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceDay_Track_TrackId",
                table: "RaceDay");

            migrationBuilder.AlterColumn<string>(
                name: "TrackId",
                table: "RaceDay",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceDay_Track_TrackId",
                table: "RaceDay",
                column: "TrackId",
                principalTable: "Track",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
