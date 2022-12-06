using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystemAPI.Migrations.TicketsDb
{
    public partial class update_ticketlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketLogs",
                table: "TicketLogs");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TLID",
                table: "TicketLogs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketLogs",
                table: "TicketLogs",
                column: "TLID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketLogs",
                table: "TicketLogs");

            migrationBuilder.DropColumn(
                name: "TLID",
                table: "TicketLogs");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketLogs",
                table: "TicketLogs",
                column: "TicketId");
        }
    }
}
