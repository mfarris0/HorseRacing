using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class SeedTrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT [dbo].[Track] ([Id], [Name], [BRISCode]) VALUES ('AP', 'Arlington Park', 'AP')");
            migrationBuilder.Sql("INSERT [dbo].[Track] ([Id], [Name], [BRISCode]) VALUES ('AQU', 'Aqueduct', 'AQU')");
            migrationBuilder.Sql("INSERT [dbo].[Track] ([Id], [Name], [BRISCode]) VALUES ('BEL', 'Belmont Park', 'BEL')");
            migrationBuilder.Sql("INSERT [dbo].[Track] ([Id], [Name], [BRISCode]) VALUES ('CD', 'Churchill Downs', 'CD')");
            migrationBuilder.Sql("INSERT [dbo].[Track] ([Id], [Name], [BRISCode]) VALUES ('FL', 'Finger Lakes Gaming & Racetrack', 'FL')");
            migrationBuilder.Sql("INSERT [dbo].[Track] ([Id], [Name], [BRISCode]) VALUES ('KEE', 'Keeneland', 'KEE')");
            migrationBuilder.Sql("INSERT [dbo].[Track] ([Id], [Name], [BRISCode]) VALUES ('PIM', 'Pimlico Race Course', 'PIM')");
            migrationBuilder.Sql("INSERT [dbo].[Track] ([Id], [Name], [BRISCode]) VALUES ('PRX', 'Parx Casino and Racing', 'PRX')");
            migrationBuilder.Sql("INSERT [dbo].[Track] ([Id], [Name], [BRISCode]) VALUES ('SA', 'Santa Anita Park', 'SA')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
