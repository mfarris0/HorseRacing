using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRacing.Data.Migrations
{
    public partial class SeedDistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT [dbo].[Distance] ([Id], [Name], [BRISCode]) VALUES ('1100', '1100 - RECONCILE', '1100')");
            migrationBuilder.Sql("INSERT [dbo].[Distance] ([Id], [Name], [BRISCode]) VALUES ('1210', '1210 - RECONCILE', '1210')");
            migrationBuilder.Sql("INSERT [dbo].[Distance] ([Id], [Name], [BRISCode]) VALUES ('1320', '1320 - RECONCILE', '1320')");
            migrationBuilder.Sql("INSERT [dbo].[Distance] ([Id], [Name], [BRISCode]) VALUES ('1430', '1430 - RECONCILE', '1430')");
            migrationBuilder.Sql("INSERT [dbo].[Distance] ([Id], [Name], [BRISCode]) VALUES ('1540', '1540 - RECONCILE', '1540')");
            migrationBuilder.Sql("INSERT [dbo].[Distance] ([Id], [Name], [BRISCode]) VALUES ('1760', '1760 - RECONCILE', '1760')");
            migrationBuilder.Sql("INSERT [dbo].[Distance] ([Id], [Name], [BRISCode]) VALUES ('1830', '1830 - RECONCILE', '1830')");
            migrationBuilder.Sql("INSERT [dbo].[Distance] ([Id], [Name], [BRISCode]) VALUES ('1870', '1870 - RECONCILE', '1870')");
            migrationBuilder.Sql("INSERT [dbo].[Distance] ([Id], [Name], [BRISCode]) VALUES ('1980', '1980 - RECONCILE', '1980')");
            migrationBuilder.Sql("INSERT [dbo].[Distance] ([Id], [Name], [BRISCode]) VALUES ('990', '990 - RECONCILE', '990')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
