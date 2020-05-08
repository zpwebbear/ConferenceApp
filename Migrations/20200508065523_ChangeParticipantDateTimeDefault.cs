using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceApp.Migrations
{
    public partial class ChangeParticipantDateTimeDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Participants",
                nullable: false,
                defaultValueSql: "CONVERT(datetime2, GETDATE())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inserted",
                table: "Participants",
                nullable: false,
                defaultValueSql: "CONVERT(datetime2, GETDATE())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Participants",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "CONVERT(datetime2, GETDATE())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inserted",
                table: "Participants",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "CONVERT(datetime2, GETDATE())");
        }
    }
}
