using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceApp.Migrations
{
    public partial class CreateSQLParticipantUpdateTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER [dbo].[Participants_UPDATE] ON [dbo].[Participants] AFTER UPDATE AS BEGIN SET NOCOUNT ON; IF((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN; UPDATE dbo.Participants SET LastUpdated = CONVERT(datetime2, GETDATE()) FROM dbo.Participants p INNER JOIN Inserted i ON p.ID = i.ID END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER [dbo].[Participants_UPDATE]");
        }
    }
}
