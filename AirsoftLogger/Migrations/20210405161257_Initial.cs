using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirsoftLogger.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Postcode);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    SiteCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Spaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => new { x.Date, x.SiteCode });
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
