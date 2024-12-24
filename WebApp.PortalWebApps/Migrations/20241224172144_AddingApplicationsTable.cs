using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalWebApps.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingApplicationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Uri = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    KeyUserName = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    KeyUserMail = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
