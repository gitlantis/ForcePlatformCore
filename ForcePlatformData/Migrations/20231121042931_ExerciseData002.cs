using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForcePlatformData.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseData002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LeftForearm",
                table: "UserParams",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LeftHand",
                table: "UserParams",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LeftUpperLimb",
                table: "UserParams",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RightForearm",
                table: "UserParams",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RightHand",
                table: "UserParams",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RightUpperLimb",
                table: "UserParams",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Reports",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeftForearm",
                table: "UserParams");

            migrationBuilder.DropColumn(
                name: "LeftHand",
                table: "UserParams");

            migrationBuilder.DropColumn(
                name: "LeftUpperLimb",
                table: "UserParams");

            migrationBuilder.DropColumn(
                name: "RightForearm",
                table: "UserParams");

            migrationBuilder.DropColumn(
                name: "RightHand",
                table: "UserParams");

            migrationBuilder.DropColumn(
                name: "RightUpperLimb",
                table: "UserParams");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Reports");
        }
    }
}
