using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class SeedRaceDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[RaceDay] ON ");
            migrationBuilder.Sql("INSERT [dbo].[RaceDay] ([Id], [RaceDate], [TrackCode], [TrackId], [RaceDateString], [RaceDayIdString]) VALUES (1, '2014-05-12T00:00:00.0000000', 'FL', 'FL', '20140512', '20140512FL')");
            migrationBuilder.Sql("INSERT [dbo].[RaceDay] ([Id], [RaceDate], [TrackCode], [TrackId], [RaceDateString], [RaceDayIdString]) VALUES (2, '2014-06-06T00:00:00.0000000', 'PIM', 'PIM', '20140606', '20140606PIM')");
            migrationBuilder.Sql("INSERT [dbo].[RaceDay] ([Id], [RaceDate], [TrackCode], [TrackId], [RaceDateString], [RaceDayIdString]) VALUES (3, '2014-12-23T00:00:00.0000000', 'PRX', 'PRX', '20141223', '20141223PRX')");
            migrationBuilder.Sql("INSERT [dbo].[RaceDay] ([Id], [RaceDate], [TrackCode], [TrackId], [RaceDateString], [RaceDayIdString]) VALUES (4, '2015-04-15T00:00:00.0000000', 'KEE', 'KEE', '20150415', '20150415KEE')");
            migrationBuilder.Sql("INSERT [dbo].[RaceDay] ([Id], [RaceDate], [TrackCode], [TrackId], [RaceDateString], [RaceDayIdString]) VALUES (5, '2015-11-19T00:00:00.0000000', 'AQU', 'AQU', '20151119', '20151119AQU')");
            migrationBuilder.Sql("INSERT [dbo].[RaceDay] ([Id], [RaceDate], [TrackCode], [TrackId], [RaceDateString], [RaceDayIdString]) VALUES (6, '2015-12-31T00:00:00.0000000', 'SA', 'SA', '20151231', '20151231SA')");
            migrationBuilder.Sql("INSERT [dbo].[RaceDay] ([Id], [RaceDate], [TrackCode], [TrackId], [RaceDateString], [RaceDayIdString]) VALUES (7, '2016-05-06T00:00:00.0000000', 'CD', 'CD', '20160506', '20160506CD')");
            migrationBuilder.Sql("INSERT [dbo].[RaceDay] ([Id], [RaceDate], [TrackCode], [TrackId], [RaceDateString], [RaceDayIdString]) VALUES (8, '2016-05-28T00:00:00.0000000', 'BEL', 'BEL', '20160528', '20160528BEL')");
            migrationBuilder.Sql("INSERT [dbo].[RaceDay] ([Id], [RaceDate], [TrackCode], [TrackId], [RaceDateString], [RaceDayIdString]) VALUES (9, '2016-08-18T00:00:00.0000000', 'AP', 'AP', '20160818', '20160818AP')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[RaceDay] OFF ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
