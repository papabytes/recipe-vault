using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure.Data.Extensions;

public static class InitializerExtensions
{
    public static async Task InitialiseDatabaseAsync(this IHost app)
    {
        using var scope = app.Services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<RecipeVaultDbContextInitializer>();

        await initializer.InitialiseAsync();
    }

    public static async Task SeedDatabaseAsync(this IHost app)
    {
        using var scope = app.Services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<RecipeVaultDbContextInitializer>();

        await initializer.TrySeedAsync();
    }
}