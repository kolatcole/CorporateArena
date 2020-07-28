using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class _6th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mode",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "BrainTeasers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "BrainTeasers");
        }
    }
}
