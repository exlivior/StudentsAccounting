using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsAccounting.Migrations
{
    public partial class rolesn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1aceb85-9128-451e-bf17-d7e6961178b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f064400a-6a51-47fc-bffb-f8f52562aa64");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7f8cc30-2ca4-4d32-ad91-a1e74db94284", "b76a376e-e8f8-4244-a171-6c2fe003d32b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9b5a819-9d6a-4720-8622-22a45acc2a25", "be560d11-a9e6-4050-8200-67b964b0f9ee", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "c1aceb85-9128-451e-bf17-d7e6961178b0", "b997c0e5-22fb-42cf-8718-d9f961ebb28e", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f064400a-6a51-47fc-bffb-f8f52562aa64", "212553a7-4378-47bc-8a14-e1ea5407e02a", "Student", null });
        }
    }
}
