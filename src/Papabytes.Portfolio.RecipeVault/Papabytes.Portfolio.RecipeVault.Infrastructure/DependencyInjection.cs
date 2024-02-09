using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Papabytes.Portfolio.RecipeVault.Domain.Repositories;
using Papabytes.Portfolio.RecipeVault.Infrastructure.Data;
using Papabytes.Portfolio.RecipeVault.Infrastructure.Repositories;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =  configuration.GetValue<string>("POSTGRES_CONNECTION_STRING");

        services.AddDbContext<RecipeVaultDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IRecipeRepository, RecipePostgresRepository>();
        services.AddScoped<ICookingStepRepository, CookingStepPostgresRepository>();
        services.AddScoped<IIngredientRepository, IngredientPostgresRepository>();
    }
}