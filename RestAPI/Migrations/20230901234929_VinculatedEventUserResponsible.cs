using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class VinculatedEventUserResponsible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Responsible",
                table: "Events",
                newName: "ResponsibleId");

            migrationBuilder.AddColumn<int>(
                name: "ResponsibleId1",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ResponsibleId1",
                table: "Events",
                column: "ResponsibleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_ResponsibleId1",
                table: "Events",
                column: "ResponsibleId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_ResponsibleId1",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ResponsibleId1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ResponsibleId1",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "ResponsibleId",
                table: "Events",
                newName: "Responsible");
        }
    }
}
