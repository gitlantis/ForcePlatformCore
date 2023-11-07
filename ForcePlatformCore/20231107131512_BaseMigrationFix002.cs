using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForcePlatformCore.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigrationFix002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LengthMeasurement",
                table: "UserParams",
                newName: "LengthUnit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LengthUnit",
                table: "UserParams",
                newName: "LengthMeasurement");
        }
    }
}
