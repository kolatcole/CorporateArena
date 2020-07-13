using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class _2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Privileges");

            migrationBuilder.AddColumn<int>(
                name: "Actions",
                table: "Privileges",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actions",
                table: "Privileges");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Privileges",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
