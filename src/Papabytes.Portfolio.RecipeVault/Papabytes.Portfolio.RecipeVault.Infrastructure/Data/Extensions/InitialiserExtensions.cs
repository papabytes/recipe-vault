using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure.Data.Extensions;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this IHost app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<RecipeVaultDbContextInitializer>();

        await initialiser.InitialiseAsync();
        // await initialiser.SeedAsync();
    }
}