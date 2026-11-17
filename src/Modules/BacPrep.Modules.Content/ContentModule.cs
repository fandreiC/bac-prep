using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace BacPrep.Modules.Content;

public static class ContentModule
{
    public static IServiceCollection AddContentModule(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
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