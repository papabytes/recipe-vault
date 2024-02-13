using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Papabytes.Portfolio.RecipeVault.Domain.Entities;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure.Data;

public class RecipeVaultDbContextInitializer
{
    private readonly ILogger<RecipeVaultDbContextInitializer> _logger;
    private readonly RecipeVaultDbContext _context;

    public RecipeVaultDbContextInitializer(ILogger<RecipeVaultDbContextInitializer> logger, RecipeVaultDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }
    
    public async Task TrySeedAsync()
    {
        if (!_context.Recipes.Any())
        {
            _context.Recipes.Add(new Recipe()
            {
                Name = "Potato stew",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Name = "potato",
                        Quantity = 1,
                        Unit = "kg",
                    },
                    new Ingredient
                    {
                        Name = "water",
                        Quantity = 1,
                        Unit = "l",
                    },
                    new Ingredient
                    {
                        Name = "salt",
                        Quantity = 1,
                        Unit = "tablespoon",
                    }
                },
                Steps = new List<CookingStep>
                {
                    new CookingStep
                    {
                        Order = 1,
                        Description = "On a pan, heat the water to a boil, and season it with the salt"
                    },
                    new CookingStep
                    {
                        Order = 2,
                        Description = "Peel the potatoes, cut them in quarters and add them to the pan, for 10 minutes"
                    },
                    new CookingStep
                    {
                        Order = 3,
                        Description = "Turn off the heat, and drain the potatoes."
                    },
                }
            });
        }

        await _context.SaveChangesAsync();
    }
}