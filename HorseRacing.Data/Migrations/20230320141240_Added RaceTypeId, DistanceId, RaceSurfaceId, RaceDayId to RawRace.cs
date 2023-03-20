using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class AddedRaceTypeIdDistanceIdRaceSurfaceIdRaceDayIdtoRawRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_Distance_DistanceId",
                table: "RawRace");

            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_RaceDay_RaceDayId",
                table: "RawRace");

            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_RaceSurface_RaceSurfaceId",
                table: "RawRace");

            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_RaceType_RaceTypeId",
                table: "RawRace");

            migrationBuilder.AlterColumn<string>(
                name: "RaceTypeId",
                table: "RawRace",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RaceSurfaceId",
                table: "RawRace",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RaceDayId",
                table: "RawRace",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DistanceId",
                table: "RawRace",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_Distance_DistanceId",
                table: "RawRace",
                column: "DistanceId",
                principalTable: "Distance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_RaceDay_RaceDayId",
                table: "RawRace",
                column: "RaceDayId",
                principalTable: "RaceDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_RaceSurface_RaceSurfaceId",
                table: "RawRace",
                column: "RaceSurfaceId",
                principalTable: "RaceSurface",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_RaceType_RaceTypeId",
                table: "RawRace",
                column: "RaceTypeId",
                principalTable: "RaceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_Distance_DistanceId",
                table: "RawRace");

            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_RaceDay_RaceDayId",
                table: "RawRace");

            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_RaceSurface_RaceSurfaceId",
                table: "RawRace");

            migrationBuilder.DropForeignKey(
                name: "FK_RawRace_RaceType_RaceTypeId",
                table: "RawRace");

            migrationBuilder.AlterColumn<string>(
                name: "RaceTypeId",
                table: "RawRace",
                type: "nvarchar(2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "RaceSurfaceId",
                table: "RawRace",
                type: "nvarchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<int>(
                name: "RaceDayId",
                table: "RawRace",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DistanceId",
                table: "RawRace",
                type: "nvarchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_Distance_DistanceId",
                table: "RawRace",
                column: "DistanceId",
                principalTable: "Distance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_RaceDay_RaceDayId",
                table: "RawRace",
                column: "RaceDayId",
                principalTable: "RaceDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_RaceSurface_RaceSurfaceId",
                table: "RawRace",
                column: "RaceSurfaceId",
                principalTable: "RaceSurface",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawRace_RaceType_RaceTypeId",
                table: "RawRace",
                column: "RaceTypeId",
                principalTable: "RaceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
