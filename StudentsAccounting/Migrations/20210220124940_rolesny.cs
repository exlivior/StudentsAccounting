using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsAccounting.Migrations
{
    public partial class rolesny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9b5a819-9d6a-4720-8622-22a45acc2a25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7f8cc30-2ca4-4d32-ad91-a1e74db94284");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d753a55-66dc-48cc-8cfe-d0efa10094e7", "cc1ad675-2b2a-4173-8027-7cb3db07b74e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca28b5e1-9526-4cea-9672-2790178be90a", "8925a95a-794c-44ca-a4d9-705bbde06d4d", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d753a55-66dc-48cc-8cfe-d0efa10094e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca28b5e1-9526-4cea-9672-2790178be90a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7f8cc30-2ca4-4d32-ad91-a1e74db94284", "b76a376e-e8f8-4244-a171-6c2fe003d32b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9b5a819-9d6a-4720-8622-22a45acc2a25", "be560d11-a9e6-4050-8200-67b964b0f9ee", "Student", "STUDENT" });
        }
    }
}
