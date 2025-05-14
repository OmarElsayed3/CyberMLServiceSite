using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberMLServiceSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class clearandupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_serviceRequests_AspNetUsers_UserId",
                table: "serviceRequests");

            migrationBuilder.DropIndex(
                name: "IX_serviceRequests_UserId",
                table: "serviceRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "serviceRequests");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "serviceRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "serviceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "serviceRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_serviceRequests_UserId",
                table: "serviceRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_serviceRequests_AspNetUsers_UserId",
                table: "serviceRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
