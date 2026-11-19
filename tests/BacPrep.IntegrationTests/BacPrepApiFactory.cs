using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BacPrep.IntegrationTests;

public sealed class BacPrepApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.UseEnvironment("Development");
        builder.UseSetting("ConnectionStrings:BacPrep", "Server=unused;Database=unused;TrustServerCertificate=True");
    }
}