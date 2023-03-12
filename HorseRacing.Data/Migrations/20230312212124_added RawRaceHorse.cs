using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class addedRawRaceHorse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawRaceHorse",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PostPosition = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    HorseName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MorningLineOdds = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    JockeyName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    WeightCarried = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TrainerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawRaceHorse", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawRaceHorse");
        }
    }
}
