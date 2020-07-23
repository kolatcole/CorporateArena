using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class _2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleLikes_Articles_ArticleID",
                table: "ArticleLikes");

            migrationBuilder.AddColumn<int>(
                name: "AricleID",
                table: "CommentLikes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentID",
                table: "CommentLikes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ArticleID",
                table: "ArticleLikes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleID",
                table: "ArticleComments",
                column: "ArticleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleComments_Articles_ArticleID",
                table: "ArticleComments",
                column: "ArticleID",
                principalTable: "Articles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleLikes_Articles_ArticleID",
                table: "ArticleLikes",
                column: "ArticleID",
                principalTable: "Articles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleComments_Articles_ArticleID",
                table: "ArticleComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleLikes_Articles_ArticleID",
                table: "ArticleLikes");

            migrationBuilder.DropIndex(
                name: "IX_ArticleComments_ArticleID",
                table: "ArticleComments");

            migrationBuilder.DropColumn(
                name: "AricleID",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "CommentLikes");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleID",
                table: "ArticleLikes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleLikes_Articles_ArticleID",
                table: "ArticleLikes",
                column: "ArticleID",
                principalTable: "Articles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
