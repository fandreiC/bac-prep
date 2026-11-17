using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BacPrep.Modules.Content;

public static class ContentModule
{
    public static IServiceCollection AddContentModule(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        var connectionString = configuration.GetConnectionString("BacPrep") ?? throw new InvalidOperationException("Connection string 'BacPrep' is missing!");

        services.AddDbContext<ContentDbContext>(options => options.UseSqlServer(connectionString, 
                        sql => sql.MigrationsHistoryTable("__EFMigrationsHistory", "content")));
        services.AddHealthChecks().AddDbContextCheck<ContentDbContext>("content-db");
        services.AddSingleton<InMemoryContentStore>();
        return services;
    }

    public static IEndpointRouteBuilder MapContentEndpoints(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);
        var group = app.MapGroup("").WithTags("Content");

        group.MapGet("/disciplines", (InMemoryContentStore store) => store.Disciplines)
            .WithSummary("List all disciplines");

        group.MapGet("/disciplines/{id:int}/syllabi",
            Results<Ok<IReadOnlyList<SyllabusDto>>, NotFound> (int id, InMemoryContentStore store) =>
            {
                if (!store.DisciplineExists(id))
                {
                    return TypedResults.NotFound();
                }
                return TypedResults.Ok(store.GetSyllabi(id));
            }).WithSummary("List the syllabi of a discipline");

        group.MapGet("/syllabi/{id:int}/tests",
            Results<Ok<IReadOnlyList<TestSummaryDto>>, NotFound> (int id, InMemoryContentStore store) =>
            {
                if (!store.SyllabusExists(id))
                {
                    return TypedResults.NotFound();
                }
                return TypedResults.Ok(store.GetTests(id));
            }).WithSummary("List the tests of a syllabus");

        return app;
    }
}