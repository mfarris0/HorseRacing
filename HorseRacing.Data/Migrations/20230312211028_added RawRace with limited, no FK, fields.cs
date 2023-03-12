using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class addedRawRacewithlimitednoFKfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawRace",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RaceNumber = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Purse = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Conditions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawRace", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawRace");
        }
    }
}
