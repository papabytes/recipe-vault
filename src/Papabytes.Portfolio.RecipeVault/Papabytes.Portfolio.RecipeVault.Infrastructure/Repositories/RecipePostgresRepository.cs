using Microsoft.EntityFrameworkCore;
using Papabytes.Portfolio.RecipeVault.Domain.Entities;
using Papabytes.Portfolio.RecipeVault.Domain.Repositories;
using Papabytes.Portfolio.RecipeVault.Infrastructure.Data;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure.Repositories;

public class RecipePostgresRepository : IRecipeRepository
{
    private readonly RecipeVaultDbContext _context;
    private readonly DbSet<Recipe> _set;

    public RecipePostgresRepository(RecipeVaultDbContext dbContext)
    {
        _context = dbContext;
        _set = dbContext.Recipes;
    }

    public async Task<Recipe?> GetByIdAsync(Guid id)
    {
        var recipe = await _set.Include(r => r.Ingredients).Include(r => r.Steps).FirstOrDefaultAsync(r => r.Id == id);
        if (recipe == null)
        {
            return recipe;
        }

        recipe.Steps = recipe.Steps.OrderBy(s => s.Order).ToList();
        return recipe;
    }

    public async Task<IEnumerable<Recipe>> SearchAsync(string search)
    {
        var normalizedSearch = search.ToUpperInvariant();
        var recipes = await _set
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .Where(r => r.Name.ToUpper().Contains(normalizedSearch))
            .ToListAsync();

        return recipes;
    }

    public async Task<Recipe> CreateAsync(Recipe recipe)
    {
        var createdRecipe = await _set.AddAsync(recipe);
        await _context.SaveChangesAsync();
        return createdRecipe.Entity;
    }

    public async Task<Recipe?> UpdateAsync(Guid id, Recipe recipe)
    {
        var existingRecipe = await _set.FindAsync(id);
        if (existingRecipe == null)
        {
            return existingRecipe;
        }

        existingRecipe.Name = recipe.Name;
        await _context.SaveChangesAsync();
        return existingRecipe;
    }

    public async Task DeleteAsync(Guid id)
    {
        var recipe = await _set.FindAsync(id);
        if (recipe == null)
        {
            return;
        }
        
        _set.Remove(recipe);
        await _context.SaveChangesAsync();
    }
}