using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class _3rd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actions",
                table: "Privileges");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Privileges",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Privileges");

            migrationBuilder.AddColumn<int>(
                name: "Actions",
                table: "Privileges",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
