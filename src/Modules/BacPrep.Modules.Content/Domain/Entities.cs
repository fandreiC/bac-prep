namespace BacPrep.Modules.Content.Domain;

internal sealed class Discipline
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Syllabus> Syllabi { get; } = [];
}

internal sealed class Profile
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Syllabus> Syllabi { get; } = [];
}

internal sealed class Syllabus
{
    public int Id { get; set; }
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; } = null!;
    public int ProfileId { get; set; }
    public Profile Profile { get; set; } = null!;
    public ICollection<Chapter> Chapters { get; } = [];
    public ICollection<Test> Tests { get; } = [];
}

internal sealed class Chapter
{
    public int Id { get; set; }
    public int SyllabusId { get; set; }
    public Syllabus Syllabus { get; set; } = null!;
    public required string Title { get; set; }
}

internal sealed class Test
{
    public int Id { get; set; }
    public int SyllabusId { get; set; }
    public Syllabus Syllabus { get; set; } = null!;
    public int Year { get; set; }
    public SessionType SessionType { get; set; }
    public int Variant { get; set; }
    public bool IsReserve { get; set; }
    public int DurationMinutes { get; set; }
    public string? GeneralNotes { get; set; }
    public ICollection<Section> Sections { get; } = [];
    public const int TotalPoints = 90;

    public bool PointsAreConsistent() => 
        Sections.Sum(s=>s.MaxPoints) == TotalPoints
        && Sections.All(s=>s.Exercises.Sum(e=>e.MaxPoints) == s.MaxPoints)
        && Sections.SelectMany(s=>s.Exercises)
            .All(e=>e.BaremItems.Count == 0 || e.BaremItems.Sum(b=>b.MaxPoints) == e.MaxPoints);
}

internal sealed class Section
{
    public int Id { get; set; }
    public int TestId { get; set; }
    public Test Test { get; set; } = null!;
    public int Number { get; set; }
    public int MaxPoints { get; set; }
    public ICollection<Exercise> Exercises { get; } = [];
}

internal sealed class Exercise
{
    public int Id { get; set; }
    public int SectionId { get; set; }
    public Section Section { get; set; } = null!;
    public int? ChapterId { get; set; }
    public Chapter? Chapter { get; set; }
    public required string Label { get; set; }
    public required string Statement { get; set; }
    public ExerciseType ExerciseType { get; set; }
    public int MaxPoints { get; set; }
    public string? AnswerKey { get; set; }
    public ICollection<BaremItem> BaremItems { get; } = [];
}

internal sealed class BaremItem
{
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;
    public string? Group { get; set; }
    public required string Description { get; set; }
    public int MaxPoints { get; set; }
    public int Order { get; set; }
}