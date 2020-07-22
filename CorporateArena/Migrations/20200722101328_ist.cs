using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class ist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleComments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 150, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ArticleID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<int>(nullable: false),
                    CommentLikesCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 150, nullable: true),
                    AuthorID = table.Column<int>(nullable: false),
                    isApproved = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    ArticleLikesCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });

            //migrationBuilder.CreateTable(
            //    name: "BrainTeasers",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Riddle = table.Column<string>(nullable: true),
            //        UserCreated = table.Column<int>(nullable: false),
            //        DateCreated = table.Column<DateTime>(nullable: false),
            //        DateModified = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BrainTeasers", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Contacts",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Email = table.Column<string>(nullable: true),
            //        Username = table.Column<string>(nullable: true),
            //        Message = table.Column<string>(nullable: true),
            //        DateCreated = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Contacts", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RolePrivileges",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleID = table.Column<int>(nullable: false),
            //        PrivilegeID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RolePrivileges", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Roles",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DateCreated = table.Column<DateTime>(nullable: false),
            //        DateModified = table.Column<DateTime>(nullable: false),
            //        UserCreated = table.Column<int>(nullable: true),
            //        UserModified = table.Column<int>(nullable: true),
            //        Name = table.Column<string>(nullable: true),
            //        DisplayName = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Roles", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TrafficUpdates",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        UserCreated = table.Column<int>(nullable: false),
            //        DateCreated = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TrafficUpdates", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserRoles",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DateCreated = table.Column<DateTime>(nullable: false),
            //        DateModified = table.Column<DateTime>(nullable: false),
            //        UserCreated = table.Column<int>(nullable: true),
            //        UserModified = table.Column<int>(nullable: true),
            //        UserID = table.Column<int>(nullable: false),
            //        RoleID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserRoles", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Vacancies",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Email = table.Column<string>(nullable: true),
            //        Url = table.Column<string>(nullable: true),
            //        JobTitle = table.Column<string>(nullable: true),
            //        JobDescription = table.Column<string>(nullable: true),
            //        Location = table.Column<string>(nullable: true),
            //        Company = table.Column<string>(nullable: true),
            //        DateCreated = table.Column<DateTime>(nullable: false),
            //        DateModified = table.Column<DateTime>(nullable: false),
            //        UserCreated = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Vacancies", x => x.ID);
            //    });

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreated = table.Column<int>(nullable: false),
                    ArticleCommentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentLikes_ArticleComments_ArticleCommentID",
                        column: x => x.ArticleCommentID,
                        principalTable: "ArticleComments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleLikes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreated = table.Column<int>(nullable: false),
                    ArticleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleLikes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArticleLikes_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateTable(
            //    name: "BrainTeaserAnswers",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DateCreated = table.Column<DateTime>(nullable: false),
            //        UserCreated = table.Column<int>(nullable: false),
            //        Answer = table.Column<string>(nullable: true),
            //        BrainTeaserID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BrainTeaserAnswers", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_BrainTeaserAnswers_BrainTeasers_BrainTeaserID",
            //            column: x => x.BrainTeaserID,
            //            principalTable: "BrainTeasers",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AppUsers",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DateCreated = table.Column<DateTime>(nullable: false),
            //        DateModified = table.Column<DateTime>(nullable: false),
            //        UserCreated = table.Column<int>(nullable: true),
            //        UserModified = table.Column<int>(nullable: true),
            //        UserName = table.Column<string>(nullable: true),
            //        FirstName = table.Column<string>(nullable: true),
            //        OtherName = table.Column<string>(nullable: true),
            //        LastName = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        IsActive = table.Column<bool>(nullable: true),
            //        IsDeleted = table.Column<bool>(nullable: true),
            //        Password = table.Column<string>(nullable: true),
            //        Token = table.Column<string>(nullable: true),
            //        RoleID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppUsers", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_AppUsers_Roles_RoleID",
            //            column: x => x.RoleID,
            //            principalTable: "Roles",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Privileges",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DateCreated = table.Column<DateTime>(nullable: false),
            //        DateModified = table.Column<DateTime>(nullable: false),
            //        UserCreated = table.Column<int>(nullable: true),
            //        UserModified = table.Column<int>(nullable: true),
            //        Name = table.Column<string>(nullable: true),
            //        DisplayName = table.Column<string>(nullable: true),
            //        Action = table.Column<string>(nullable: true),
            //        Entity = table.Column<string>(nullable: true),
            //        RoleID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Privileges", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Privileges_Roles_RoleID",
            //            column: x => x.RoleID,
            //            principalTable: "Roles",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TrafficComments",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserCreated = table.Column<int>(nullable: false),
            //        DateCreated = table.Column<DateTime>(nullable: false),
            //        Comment = table.Column<string>(nullable: true),
            //        TrafficUpdateID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TrafficComments", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_TrafficComments_TrafficUpdates_TrafficUpdateID",
            //            column: x => x.TrafficUpdateID,
            //            principalTable: "TrafficUpdates",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppUsers_RoleID",
            //    table: "AppUsers",
            //    column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleLikes_ArticleID",
                table: "ArticleLikes",
                column: "ArticleID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BrainTeaserAnswers_BrainTeaserID",
            //    table: "BrainTeaserAnswers",
            //    column: "BrainTeaserID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_ArticleCommentID",
                table: "CommentLikes",
                column: "ArticleCommentID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Privileges_RoleID",
            //    table: "Privileges",
            //    column: "RoleID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TrafficComments_TrafficUpdateID",
            //    table: "TrafficComments",
            //    column: "TrafficUpdateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "ArticleLikes");

            migrationBuilder.DropTable(
                name: "BrainTeaserAnswers");

            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Privileges");

            migrationBuilder.DropTable(
                name: "RolePrivileges");

            migrationBuilder.DropTable(
                name: "TrafficComments");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "BrainTeasers");

            migrationBuilder.DropTable(
                name: "ArticleComments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TrafficUpdates");
        }
    }
}
