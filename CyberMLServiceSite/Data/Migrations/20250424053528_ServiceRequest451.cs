using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberMLServiceSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class ServiceRequest451 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceRequested",
                table: "serviceRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceRequested",
                table: "serviceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
