using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class SeedRaceSurface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT [dbo].[RaceSurface] ([Id], [Name], [BRISCode]) VALUES ('D', 'Dirt', 'D')");
            migrationBuilder.Sql("INSERT [dbo].[RaceSurface] ([Id], [Name], [BRISCode]) VALUES ('T', 'Turf', 'T')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
