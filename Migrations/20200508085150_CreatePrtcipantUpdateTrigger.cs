using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceApp.Migrations
{
    public partial class CreatePrtcipantUpdateTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Participants",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CONVERT(datetime2, GETDATE())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Participants",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CONVERT(datetime2, GETDATE())",
                oldClrType: typeof(DateTime));
        }
    }
}
