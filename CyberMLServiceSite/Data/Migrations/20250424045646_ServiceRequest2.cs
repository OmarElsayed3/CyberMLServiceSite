using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberMLServiceSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class ServiceRequest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "serviceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "serviceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "serviceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceRequested",
                table: "serviceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "serviceRequests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "serviceRequests");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "serviceRequests");

            migrationBuilder.DropColumn(
                name: "ServiceRequested",
                table: "serviceRequests");
        }
    }
}
