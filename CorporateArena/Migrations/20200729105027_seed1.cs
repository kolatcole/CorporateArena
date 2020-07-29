using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Privileges");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Privileges");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Privileges");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Privileges");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Action", "DisplayName", "Entity", "Name" },
                values: new object[] { "Create", "Create User", "User", "CreateUser" });

            migrationBuilder.InsertData(
                table: "Privileges",
                columns: new[] { "ID", "Action", "DisplayName", "Entity", "Name", "RoleID" },
                values: new object[,]
                {
                    { 24, "Delete", "Delete TrafficUpdates", "TrafficUpdates", "DeleteTrafficUpdates", null },
                    { 23, "Update", "Update TrafficUpdates", "TrafficUpdates", "UpdateTrafficUpdates", null },
                    { 22, "Read", "Read TrafficUpdates", "TrafficUpdates", "ReadTrafficUpdates", null },
                    { 21, "Create", "Create TrafficUpdates", "TrafficUpdates", "CreateTrafficUpdates", null },
                    { 20, "Delete", "Delete Article", "Article", "DeleteArticle", null },
                    { 19, "Update", "Update Article", "Article", "UpdateArticle", null },
                    { 18, "Read", "Read Article", "Article", "ReadArticle", null },
                    { 17, "Create", "Create Article", "Article", "CreateArticle", null },
                    { 16, "Delete", "Delete Vacancy", "Vacancy", "DeleteVacancy", null },
                    { 15, "Update", "Update Vacancy", "Vacancy", "UpdateVacancy", null },
                    { 14, "Read", "Read Vacancy", "Vacancy", "ReadVacancy", null },
                    { 2, "Read", "Read User", "User", "ReadUser", null },
                    { 12, "Delete", "Delete BrainTeaser", "BrainTeaser", "DeleteBrainTeaser", null },
                    { 13, "Create", "Create Vacancy", "Vacancy", "CreateVacancy", null },
                    { 3, "Update", "Update User", "User", "UpdateUser", null },
                    { 5, "Create", "Create Role", "Role", "CreateRole", null },
                    { 6, "Read", "Read Role", "Role", "ReadRole", null },
                    { 4, "Delete", "Delete User", "User", "DeleteUser", null },
                    { 8, "Delete", "Delete Role", "Role", "DeleteRole", null },
                    { 9, "Create", "Create BrainTeaser", "BrainTeaser", "CreateBrainTeaser", null },
                    { 10, "Read", "Read BrainTeaser", "BrainTeaser", "ReadBrainTeaser", null },
                    { 11, "Update", "Update BrainTeaser", "BrainTeaser", "UpdateBrainTeaser", null },
                    { 7, "Update", "Update Role", "Role", "UpdateRole", null }
                });

            migrationBuilder.InsertData(
                table: "RolePrivileges",
                columns: new[] { "ID", "PrivilegeID", "RoleID" },
                values: new object[,]
                {
                    { 22, 16, 1 },
                    { 18, 12, 1 },
                    { 19, 13, 1 },
                    { 20, 14, 1 },
                    { 21, 15, 1 },
                    { 23, 17, 1 },
                    { 28, 22, 1 },
                    { 25, 19, 1 },
                    { 26, 20, 1 },
                    { 27, 21, 1 },
                    { 17, 11, 1 },
                    { 29, 23, 1 },
                    { 30, 24, 1 },
                    { 24, 18, 1 },
                    { 16, 10, 1 },
                    { 10, 4, 1 },
                    { 14, 8, 1 },
                    { 1, 2, 2 },
                    { 2, 6, 2 },
                    { 3, 10, 2 },
                    { 15, 9, 1 },
                    { 6, 22, 2 },
                    { 5, 18, 2 },
                    { 8, 2, 1 },
                    { 9, 3, 1 },
                    { 11, 5, 1 },
                    { 12, 6, 1 },
                    { 13, 7, 1 },
                    { 7, 1, 1 },
                    { 4, 14, 2 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "DateCreated", "DateModified", "DisplayName", "Name", "UserCreated", "UserModified" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 7, 29, 11, 50, 26, 18, DateTimeKind.Local).AddTicks(1245), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic", "Basic", 1, null },
                    { 1, new DateTime(2020, 7, 29, 11, 50, 26, 16, DateTimeKind.Local).AddTicks(6205), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SuperUser", "SuperUser", 1, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "ID", "DateCreated", "DateModified", "RoleID", "UserCreated", "UserID", "UserModified" },
                values: new object[] { 1, new DateTime(2020, 7, 29, 11, 50, 26, 18, DateTimeKind.Local).AddTicks(9705), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, null });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "ID", "DateCreated", "DateModified", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "OtherName", "Password", "PhoneNumber", "RoleID", "Token", "UserCreated", "UserModified", "UserName" },
                values: new object[] { 1, new DateTime(2020, 7, 29, 11, 50, 26, 18, DateTimeKind.Local).AddTicks(5357), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tkolawole@Inspirecoders.com", "System", true, null, "User", null, null, null, 1, null, null, null, "System Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Privileges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Privileges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "Privileges",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserModified",
                table: "Privileges",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Action", "DateCreated", "DateModified", "DisplayName", "Entity", "Name", "UserCreated", "UserModified" },
                values: new object[] { "act", new DateTime(2020, 7, 29, 10, 52, 56, 443, DateTimeKind.Local).AddTicks(9134), new DateTime(2020, 7, 29, 10, 52, 56, 445, DateTimeKind.Local).AddTicks(5659), "test", "testEnt", "dd", 1, 1 });
        }
    }
}
