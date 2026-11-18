using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BacPrep.Modules.Content;

public static class ContentModule
{
    public static IServiceCollection AddContentModule(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        var connectionString = configuration.GetConnectionString("BacPrep")
            ?? throw new InvalidOperationException("Connection string 'BacPrep' is missing.");

        services.AddDbContext<ContentDbContext>(options =>
            options.UseSqlServer(connectionString,
                sql => sql.MigrationsHistoryTable("__EFMigrationsHistory", "content")));

        services.AddHealthChecks().AddDbContextCheck<ContentDbContext>("content-db");

        return services;
    }

    public static IEndpointRouteBuilder MapContentEndpoints(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);
        var group = app.MapGroup("").WithTags("Content");

        group.MapGet("/disciplines", GetDisciplines)
            .WithSummary("List all disciplines");
        group.MapGet("/disciplines/{id:int}/syllabi", GetSyllabi)
            .WithSummary("List the syllabi of a discipline");
        group.MapGet("/syllabi/{id:int}/tests", GetTests)
            .WithSummary("List the tests of a syllabus");
        group.MapGet("/tests/{id:int}", GetTest)
            .WithSummary("Get a test with its sections and exercises");

        return app;
    }

    private static async Task<Ok<List<DisciplineDto>>> GetDisciplines(
        ContentDbContext db, CancellationToken ct)
    {
        var disciplines = await db.Disciplines
            .AsNoTracking()
            .OrderBy(d => d.Id)
            .Select(d => new DisciplineDto(d.Id, d.Name))
            .ToListAsync(ct);

        return TypedResults.Ok(disciplines);
    }

    private static async Task<Results<Ok<List<SyllabusDto>>, NotFound>> GetSyllabi(
        int id, ContentDbContext db, CancellationToken ct)
    {
        if (!await db.Disciplines.AnyAsync(d => d.Id == id, ct))
        {
            return TypedResults.NotFound();
        }

        var syllabi = await db.Syllabi
            .AsNoTracking()
            .Where(s => s.DisciplineId == id)
            .OrderBy(s => s.Id)
            .Select(s => new SyllabusDto(s.Id, s.DisciplineId, s.Profile.Name))
            .ToListAsync(ct);

        return TypedResults.Ok(syllabi);
    }

    private static async Task<Results<Ok<List<TestSummaryDto>>, NotFound>> GetTests(
        int id, ContentDbContext db, CancellationToken ct)
    {
        if (!await db.Syllabi.AnyAsync(s => s.Id == id, ct))
        {
            return TypedResults.NotFound();
        }

        var tests = await db.Tests
            .AsNoTracking()
            .Where(t => t.SyllabusId == id)
            .OrderByDescending(t => t.Year)
            .ThenBy(t => t.Variant)
            .Select(t => new TestSummaryDto(t.Id, t.SyllabusId, t.Year, t.SessionType, t.Variant))
            .ToListAsync(ct);

        return TypedResults.Ok(tests);
    }

    private static async Task<Results<Ok<TestDetailsDto>, NotFound>> GetTest(
        int id, ContentDbContext db, CancellationToken ct)
    {
        var test = await db.Tests
            .AsNoTracking()
            .Where(t => t.Id == id)
            .Select(t => new TestDetailsDto(
                t.Id, t.Year, t.SessionType, t.Variant, t.DurationMinutes, t.GeneralNotes,
                t.Sections
                    .OrderBy(s => s.Number)
                    .Select(s => new SectionDto(
                        s.Number, s.MaxPoints,
                        s.Exercises
                            .OrderBy(e => e.Id)
                            .Select(e => new ExerciseDto(e.Id, e.Label, e.ExerciseType, e.MaxPoints))
                            .ToList()))
                    .ToList()))
            .SingleOrDefaultAsync(ct);

        return test is null ? TypedResults.NotFound() : TypedResults.Ok(test);
    }
}