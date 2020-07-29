using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Privileges",
                columns: new[] { "ID", "Action", "DateCreated", "DateModified", "DisplayName", "Entity", "Name", "RoleID", "UserCreated", "UserModified" },
                values: new object[] { 1, "act", new DateTime(2020, 7, 29, 10, 52, 56, 443, DateTimeKind.Local).AddTicks(9134), new DateTime(2020, 7, 29, 10, 52, 56, 445, DateTimeKind.Local).AddTicks(5659), "test", "testEnt", "dd", null, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
