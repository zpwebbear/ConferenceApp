using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceApp.Migrations
{
    public partial class RolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03471798-d73f-4f1d-9549-c23230599044", "09635c8b-a49f-481b-b7cc-7098df0840fd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cbb702ef-1ce2-43f2-9ad9-e7005ed3487d", "b298f2ce-5ac6-4e68-8a1d-295f2328fdfe", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "661da2a5-3776-4feb-8e95-da5686c706ee", "e141ac07-c44e-4806-90c0-1267e4f62240", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03471798-d73f-4f1d-9549-c23230599044");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661da2a5-3776-4feb-8e95-da5686c706ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbb702ef-1ce2-43f2-9ad9-e7005ed3487d");
        }
    }
}
