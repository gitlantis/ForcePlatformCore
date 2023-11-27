using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForcePlatformData.Migrations
{
    /// <inheritdoc />
    public partial class BasMigration002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Reports",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FilterLength",
                table: "Reports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "FilterLength",
                table: "Reports");
        }
    }
}
