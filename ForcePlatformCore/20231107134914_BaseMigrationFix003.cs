using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForcePlatformCore.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigrationFix003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BodyWight",
                table: "UserParams",
                newName: "BodyWeight");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BodyWeight",
                table: "UserParams",
                newName: "BodyWight");
        }
    }
}
