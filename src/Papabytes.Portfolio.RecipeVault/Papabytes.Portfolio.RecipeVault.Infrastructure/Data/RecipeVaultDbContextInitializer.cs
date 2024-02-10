using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
}