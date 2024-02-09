using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Papabytes.Portfolio.RecipeVault.Domain.Entities;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure.Data;

public class RecipeVaultDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<CookingStep> CookingSteps { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    
    public RecipeVaultDbContext(DbContextOptions<RecipeVaultDbContext> options) : base(options) { }

    public RecipeVaultDbContext()
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}