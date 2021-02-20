using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsAccounting.Migrations
{
    public partial class rolesnyr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "8997d93d-0a09-4ccb-b13e-1d33d4b72d31", "516ef96c-35da-4ccf-9669-07a8faae3517", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f18477b-90e9-4830-a2d9-ad76a2eff051", "076be2b2-2938-4fbb-9ef7-6e41a19118df", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8997d93d-0a09-4ccb-b13e-1d33d4b72d31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f18477b-90e9-4830-a2d9-ad76a2eff051");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d753a55-66dc-48cc-8cfe-d0efa10094e7", "cc1ad675-2b2a-4173-8027-7cb3db07b74e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca28b5e1-9526-4cea-9672-2790178be90a", "8925a95a-794c-44ca-a4d9-705bbde06d4d", "Student", "STUDENT" });
        }
    }
}
