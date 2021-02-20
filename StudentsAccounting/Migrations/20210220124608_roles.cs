using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsAccounting.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1aceb85-9128-451e-bf17-d7e6961178b0", "b997c0e5-22fb-42cf-8718-d9f961ebb28e", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f064400a-6a51-47fc-bffb-f8f52562aa64", "212553a7-4378-47bc-8a14-e1ea5407e02a", "Student", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1aceb85-9128-451e-bf17-d7e6961178b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f064400a-6a51-47fc-bffb-f8f52562aa64");
        }
    }
}
