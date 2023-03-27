using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class SeedRaceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('A', 'Allowance', 'A')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('AO', 'Allowance Optional Claiming', 'AO')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('C', 'Claiming', 'C')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('CO', 'Optional Claiming', 'CO')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('G1', 'Grade I Stakes/Handicap', 'G1')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('G2', 'Grade II Stakes/Handicap', 'G2')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('G3', 'Grade III Stakes/Handicap', 'G3')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('M', 'Maiden Claiming', 'M')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('', 'Nongraded Stake/Handicap', '')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('R', 'Starter Allowance', 'R')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('S', 'Maiden Special Weight', 'S')");
            migrationBuilder.Sql("INSERT [dbo].[RaceType] ([Id], [Name], [BRISCode]) VALUES ('T', 'Starter Handicap', 'T')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
