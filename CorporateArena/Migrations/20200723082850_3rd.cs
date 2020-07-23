using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class _3rd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AricleID",
                table: "CommentLikes");

            migrationBuilder.AddColumn<int>(
                name: "ArticleID",
                table: "CommentLikes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleID",
                table: "CommentLikes");

            migrationBuilder.AddColumn<int>(
                name: "AricleID",
                table: "CommentLikes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
