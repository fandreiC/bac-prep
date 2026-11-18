using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BacPrep.Modules.Content.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedReferenceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "content",
                table: "Disciplines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Matematică" },
                    { 2, "Limba și literatura română" },
                    { 3, "Informatică" }
                });

            migrationBuilder.InsertData(
                schema: "content",
                table: "Profiles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mate-Info" },
                    { 2, "Științe ale naturii" },
                    { 3, "Tehnologic" },
                    { 4, "Pedagogic" },
                    { 5, "Real" },
                    { 6, "Uman" }
                });

            migrationBuilder.InsertData(
                schema: "content",
                table: "Syllabi",
                columns: new[] { "Id", "DisciplineId", "ProfileId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 },
                    { 7, 3, 1 },
                    { 8, 3, 2 }
                });

            migrationBuilder.InsertData(
                schema: "content",
                table: "Tests",
                columns: new[] { "Id", "DurationMinutes", "GeneralNotes", "IsReserve", "SessionType", "SyllabusId", "Variant", "Year" },
                values: new object[] { 1, 180, "Se acordă 10 puncte din oficiu. Nota finală se calculează prin împărțirea la 10 a punctajului total.", false, "Summer", 1, 3, 2026 });

            migrationBuilder.InsertData(
                schema: "content",
                table: "Sections",
                columns: new[] { "Id", "MaxPoints", "Number", "TestId" },
                values: new object[,]
                {
                    { 1, 30, 1, 1 },
                    { 2, 30, 2, 1 },
                    { 3, 30, 3, 1 }
                });

            migrationBuilder.InsertData(
                schema: "content",
                table: "Exercises",
                columns: new[] { "Id", "AnswerKey", "ChapterId", "ExerciseType", "Label", "MaxPoints", "SectionId", "Statement" },
                values: new object[,]
                {
                    { 1, null, null, "Numeric", "1", 5, 1, "Enunțul va fi adăugat din subiectul oficial." },
                    { 2, null, null, "Numeric", "2", 5, 1, "Enunțul va fi adăugat din subiectul oficial." },
                    { 3, null, null, "Numeric", "3", 5, 1, "Enunțul va fi adăugat din subiectul oficial." },
                    { 4, null, null, "Numeric", "4", 5, 1, "Enunțul va fi adăugat din subiectul oficial." },
                    { 5, null, null, "Numeric", "5", 5, 1, "Enunțul va fi adăugat din subiectul oficial." },
                    { 6, null, null, "Numeric", "6", 5, 1, "Enunțul va fi adăugat din subiectul oficial." },
                    { 7, null, null, "Numeric", "1.a", 5, 2, "Enunțul va fi adăugat din subiectul oficial." },
                    { 8, null, null, "Numeric", "1.b", 5, 2, "Enunțul va fi adăugat din subiectul oficial." },
                    { 9, null, null, "Numeric", "1.c", 5, 2, "Enunțul va fi adăugat din subiectul oficial." },
                    { 10, null, null, "Numeric", "2.a", 5, 2, "Enunțul va fi adăugat din subiectul oficial." },
                    { 11, null, null, "Numeric", "2.b", 5, 2, "Enunțul va fi adăugat din subiectul oficial." },
                    { 12, null, null, "Numeric", "2.c", 5, 2, "Enunțul va fi adăugat din subiectul oficial." },
                    { 13, null, null, "Numeric", "1.a", 5, 3, "Enunțul va fi adăugat din subiectul oficial." },
                    { 14, null, null, "Numeric", "1.b", 5, 3, "Enunțul va fi adăugat din subiectul oficial." },
                    { 15, null, null, "Numeric", "1.c", 5, 3, "Enunțul va fi adăugat din subiectul oficial." },
                    { 16, null, null, "Numeric", "2.a", 5, 3, "Enunțul va fi adăugat din subiectul oficial." },
                    { 17, null, null, "Numeric", "2.b", 5, 3, "Enunțul va fi adăugat din subiectul oficial." },
                    { 18, null, null, "Numeric", "2.c", 5, 3, "Enunțul va fi adăugat din subiectul oficial." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Syllabi",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Syllabi",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Syllabi",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Syllabi",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Syllabi",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Syllabi",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Syllabi",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Syllabi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "content",
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
