using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalWebApps.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSystemConfigurationAddingStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "SystemConfigurations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SystemConfigurations");
        }
    }
}
