using Microsoft.EntityFrameworkCore.Migrations;

namespace AirsoftLogger.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
