using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BacPrep.Modules.Content.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "content");

            migrationBuilder.CreateTable(
                name: "Disciplines",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Syllabi",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Syllabi_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalSchema: "content",
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Syllabi_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "content",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SyllabusId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Syllabi_SyllabusId",
                        column: x => x.SyllabusId,
                        principalSchema: "content",
                        principalTable: "Syllabi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SyllabusId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SessionType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Variant = table.Column<int>(type: "int", nullable: false),
                    IsReserve = table.Column<bool>(type: "bit", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    GeneralNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Syllabi_SyllabusId",
                        column: x => x.SyllabusId,
                        principalSchema: "content",
                        principalTable: "Syllabi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    MaxPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Tests_TestId",
                        column: x => x.TestId,
                        principalSchema: "content",
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaxPoints = table.Column<int>(type: "int", nullable: false),
                    AnswerKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalSchema: "content",
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_Sections_SectionId",
                        column: x => x.SectionId,
                        principalSchema: "content",
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaremItems",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MaxPoints = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaremItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaremItems_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalSchema: "content",
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaremItems_ExerciseId",
                schema: "content",
                table: "BaremItems",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_SyllabusId",
                schema: "content",
                table: "Chapters",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_Name",
                schema: "content",
                table: "Disciplines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ChapterId",
                schema: "content",
                table: "Exercises",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_SectionId",
                schema: "content",
                table: "Exercises",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Name",
                schema: "content",
                table: "Profiles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_TestId_Number",
                schema: "content",
                table: "Sections",
                columns: new[] { "TestId", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Syllabi_DisciplineId_ProfileId",
                schema: "content",
                table: "Syllabi",
                columns: new[] { "DisciplineId", "ProfileId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Syllabi_ProfileId",
                schema: "content",
                table: "Syllabi",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SyllabusId_Year_SessionType_Variant_IsReserve",
                schema: "content",
                table: "Tests",
                columns: new[] { "SyllabusId", "Year", "SessionType", "Variant", "IsReserve" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaremItems",
                schema: "content");

            migrationBuilder.DropTable(
                name: "Exercises",
                schema: "content");

            migrationBuilder.DropTable(
                name: "Chapters",
                schema: "content");

            migrationBuilder.DropTable(
                name: "Sections",
                schema: "content");

            migrationBuilder.DropTable(
                name: "Tests",
                schema: "content");

            migrationBuilder.DropTable(
                name: "Syllabi",
                schema: "content");

            migrationBuilder.DropTable(
                name: "Disciplines",
                schema: "content");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "content");
        }
    }
}
