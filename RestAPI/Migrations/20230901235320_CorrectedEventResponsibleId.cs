using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedEventResponsibleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ResponsibleId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ResponsibleId",
                table: "Events",
                column: "ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_ResponsibleId",
                table: "Events",
                column: "ResponsibleId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_ResponsibleId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ResponsibleId",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsibleId",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
