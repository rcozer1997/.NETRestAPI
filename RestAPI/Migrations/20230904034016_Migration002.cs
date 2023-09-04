using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class Migration002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_ResponsibleId1",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ResponsibleId1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ResponsibleId1",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsibleId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EventsParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsParticipants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsParticipants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ResponsibleId",
                table: "Events",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsParticipants_EventId",
                table: "EventsParticipants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsParticipants_UserId",
                table: "EventsParticipants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_ResponsibleId",
                table: "Events",
                column: "ResponsibleId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_ResponsibleId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventsParticipants");

            migrationBuilder.DropIndex(
                name: "IX_Events_ResponsibleId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsibleId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleId1",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ResponsibleId1",
                table: "Events",
                column: "ResponsibleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_ResponsibleId1",
                table: "Events",
                column: "ResponsibleId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
