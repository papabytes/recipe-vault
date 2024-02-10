using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure.Data;

public class RecipeVaultDbContextFactory : IDesignTimeDbContextFactory<RecipeVaultDbContext>
{
    public RecipeVaultDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RecipeVaultDbContext>();
        optionsBuilder.UseNpgsql("postgresql://postgres:example@localhost/recipe-vault");

        return new RecipeVaultDbContext(optionsBuilder.Options);
    }
}