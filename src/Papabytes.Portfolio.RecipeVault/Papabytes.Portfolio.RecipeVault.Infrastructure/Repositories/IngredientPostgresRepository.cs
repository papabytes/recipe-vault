using Microsoft.EntityFrameworkCore;
using Papabytes.Portfolio.RecipeVault.Domain.Entities;
using Papabytes.Portfolio.RecipeVault.Domain.Repositories;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure.Repositories;

public class IngredientPostgresRepository : IIngredientRepository
{
    private readonly DbSet<Ingredient> _set;
    private readonly RecipeVaultDbContext _context;

    public IngredientPostgresRepository(RecipeVaultDbContext dbContext)
    {
        _context = dbContext;
        _set = dbContext.Ingredients;
    }

    public async Task<Ingredient?> GetByIdAsync(Guid id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsByRecipeAsync(Guid recipeId)
    {
        return await _set.Where(r => r.RecipeId == recipeId).ToListAsync();
    }

    public async Task<Ingredient> CreateIngredientASync(Ingredient ingredient)
    {
        var addResult = await _set.AddAsync(ingredient);
        await _context.SaveChangesAsync();
        return addResult.Entity;
    }

    public async Task<Ingredient?> UpdateIngredientAsync(Guid id, Ingredient ingredient)
    {
        var existingIngredient = await _set.FindAsync(id);
        if (existingIngredient == null)
        {
            return null;
        }

        existingIngredient.Name = ingredient.Name;
        existingIngredient.Quantity = ingredient.Quantity;
        existingIngredient.Unit = ingredient.Unit;

        await _context.SaveChangesAsync();
        return existingIngredient;
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var existingIngredient = await _set.FindAsync(id);
        if (existingIngredient == null)
        {
            return;
        }

        _set.Remove(existingIngredient);
        await _context.SaveChangesAsync();
    }
}