using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ForcePlatformData.Migrations
{
    /// <inheritdoc />
    public partial class BasMigration001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypeId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    ExerciseTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserParams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    LeftSole = table.Column<double>(type: "REAL", nullable: true),
                    LeftShin = table.Column<double>(type: "REAL", nullable: true),
                    LeftTigh = table.Column<double>(type: "REAL", nullable: true),
                    RightSole = table.Column<double>(type: "REAL", nullable: true),
                    RightShin = table.Column<double>(type: "REAL", nullable: true),
                    RightTigh = table.Column<double>(type: "REAL", nullable: true),
                    LeftHand = table.Column<double>(type: "REAL", nullable: true),
                    LeftForearm = table.Column<double>(type: "REAL", nullable: true),
                    LeftUpperLimb = table.Column<double>(type: "REAL", nullable: true),
                    RightHand = table.Column<double>(type: "REAL", nullable: true),
                    RightForearm = table.Column<double>(type: "REAL", nullable: true),
                    RightUpperLimb = table.Column<double>(type: "REAL", nullable: true),
                    LengthUnit = table.Column<string>(type: "TEXT", nullable: false),
                    BodyHeight = table.Column<double>(type: "REAL", nullable: true),
                    BodyWeight = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserParamId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserParams_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Stability, 1st platform" },
                    { 2, "Jump, 2 platforms" },
                    { 3, "Gait, 4 platforms" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ExerciseTypeId",
                table: "Reports",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Id",
                table: "Reports",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserParams_Id",
                table: "UserParams",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserParams_UserId",
                table: "UserParams",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "UserParams");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
