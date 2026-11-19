namespace BacPrep.IntegrationTests;

public sealed class ApiStartupTests(BacPrepApiFactory factory) : IClassFixture<BacPrepApiFactory>
{
    [Fact]
    public async Task OpenApiDocumentListsContentEndpoints()
    {
        using var client = factory.CreateClient();

        var json = await client.GetStringAsync(new Uri("/openapi/v1.json", UriKind.Relative));

        Assert.Contains("/disciplines", json, StringComparison.Ordinal);
        Assert.Contains("/tests/{id}", json, StringComparison.Ordinal);
    }
}