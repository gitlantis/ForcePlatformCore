using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForcePlatformCore.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigrationFix004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserParams_UserParamsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserParamsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserParamsId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserParams",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserParams_UserId",
                table: "UserParams",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserParams_Users_UserId",
                table: "UserParams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserParams_Users_UserId",
                table: "UserParams");

            migrationBuilder.DropIndex(
                name: "IX_UserParams_UserId",
                table: "UserParams");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserParams");

            migrationBuilder.AddColumn<int>(
                name: "UserParamsId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserParamsId",
                table: "Users",
                column: "UserParamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserParams_UserParamsId",
                table: "Users",
                column: "UserParamsId",
                principalTable: "UserParams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
