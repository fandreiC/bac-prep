using System.Globalization;
using BacPrep.Modules.Content.Domain;
using Microsoft.EntityFrameworkCore;

namespace BacPrep.Modules.Content.Persistence;

internal static class ContentSeedData
{
    private const string StatementPlaceholder = "Enunțul va fi adăugat din subiectul oficial.";

    public static void Apply(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Discipline>().HasData(
            new Discipline { Id = 1, Name = "Matematică" },
            new Discipline { Id = 2, Name = "Limba și literatura română" },
            new Discipline { Id = 3, Name = "Informatică" });

        modelBuilder.Entity<Profile>().HasData(
            new Profile { Id = 1, Name = "Mate-Info" },
            new Profile { Id = 2, Name = "Științe ale naturii" },
            new Profile { Id = 3, Name = "Tehnologic" },
            new Profile { Id = 4, Name = "Pedagogic" },
            new Profile { Id = 5, Name = "Real" },
            new Profile { Id = 6, Name = "Uman" });

        modelBuilder.Entity<Syllabus>().HasData(
            new Syllabus { Id = 1, DisciplineId = 1, ProfileId = 1 },
            new Syllabus { Id = 2, DisciplineId = 1, ProfileId = 2 },
            new Syllabus { Id = 3, DisciplineId = 1, ProfileId = 3 },
            new Syllabus { Id = 4, DisciplineId = 1, ProfileId = 4 },
            new Syllabus { Id = 5, DisciplineId = 2, ProfileId = 5 },
            new Syllabus { Id = 6, DisciplineId = 2, ProfileId = 6 },
            new Syllabus { Id = 7, DisciplineId = 3, ProfileId = 1 },
            new Syllabus { Id = 8, DisciplineId = 3, ProfileId = 2 });

        // Matematică, Mate-Info, sesiunea de vară 2026, varianta 3
        modelBuilder.Entity<Test>().HasData(
            new Test
            {
                Id = 1,
                SyllabusId = 1,
                Year = 2026,
                SessionType = SessionType.Summer,
                Variant = 3,
                IsReserve = false,
                DurationMinutes = 180,
                GeneralNotes = "Se acordă 10 puncte din oficiu. Nota finală se calculează prin împărțirea la 10 a punctajului total."
            });

        modelBuilder.Entity<Section>().HasData(
            new Section { Id = 1, TestId = 1, Number = 1, MaxPoints = 30 },
            new Section { Id = 2, TestId = 1, Number = 2, MaxPoints = 30 },
            new Section { Id = 3, TestId = 1, Number = 3, MaxPoints = 30 });

        modelBuilder.Entity<Exercise>().HasData(MathSummer2026Variant3Exercises());
    }

    private static List<Exercise> MathSummer2026Variant3Exercises()
    {
        List<Exercise> exercises = [];
        var id = 1;

        // Subiectul I: items 1-6, 5 points each
        for (var item = 1; item <= 6; item++)
        {
            exercises.Add(NewExercise(id++, sectionId: 1, item.ToString(CultureInfo.InvariantCulture)));
        }

        // Subiectul II and III: 2 problems x 3 parts, 5 points each
        string[] partLabels = ["1.a", "1.b", "1.c", "2.a", "2.b", "2.c"];
        foreach (var label in partLabels)
        {
            exercises.Add(NewExercise(id++, sectionId: 2, label));
        }
        foreach (var label in partLabels)
        {
            exercises.Add(NewExercise(id++, sectionId: 3, label));
        }

        return exercises;
    }

    private static Exercise NewExercise(int id, int sectionId, string label) => new()
    {
        Id = id,
        SectionId = sectionId,
        Label = label,
        Statement = StatementPlaceholder,
        ExerciseType = ExerciseType.Numeric,
        MaxPoints = 5
    };
}