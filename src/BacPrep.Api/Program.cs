var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<SingletonId>();
builder.Services.AddScoped<ScopedId>();
builder.Services.AddTransient<TransientId>();

var app = builder.Build();

app.MapGet("/lifetimes", (SingletonId s, ScopedId sc1, ScopedId sc2, TransientId t1, TransientId t2) =>
    new { Singleton = s.Id, Scoped1 = sc1.Id, Scoped2 = sc2.Id, Transient1 = t1.Id, Transient2 = t2.Id });


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

sealed record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

sealed class SingletonId{public Guid Id {get;} = Guid.NewGuid();}
sealed class ScopedId{public Guid Id {get;} = Guid.NewGuid();}
sealed class TransientId{public Guid Id {get;} = Guid.NewGuid();}