using Microsoft.EntityFrameworkCore;
using Papabytes.Portfolio.RecipeVault.Domain.Entities;
using Papabytes.Portfolio.RecipeVault.Domain.Repositories;
using Papabytes.Portfolio.RecipeVault.Infrastructure.Data;

namespace Papabytes.Portfolio.RecipeVault.Infrastructure.Repositories;

public class CookingStepPostgresRepository : ICookingStepRepository
{
    private readonly RecipeVaultDbContext _context;
    private readonly DbSet<CookingStep> _set;

    public CookingStepPostgresRepository(RecipeVaultDbContext dbContext)
    {
        _context = dbContext;
        _set = dbContext.Set<CookingStep>();
    }
    
    public async Task<IEnumerable<CookingStep>> GetCookingStepsByRecipeAsync(Guid recipeId)
    {
        return await _set.Where(s => s.RecipeId == recipeId).OrderBy(s => s.Order).ToListAsync();
    }

    public async Task<CookingStep> CreateCookingStepAsync(CookingStep cookingStep)
    {
        var addResult = await _set.AddAsync(cookingStep);
        await _context.SaveChangesAsync();
        return addResult.Entity;
    }

    public async Task<CookingStep?> UpdateCookingStepAsync(Guid id, CookingStep cookingStep)
    {
        var cookingStepToUpdate = await _set.FindAsync(id);
        if (cookingStepToUpdate == null)
        {
            return cookingStepToUpdate;
        }

        cookingStepToUpdate.Order = cookingStep.Order;
        cookingStepToUpdate.Description = cookingStep.Description;

        await _context.SaveChangesAsync();
        return cookingStepToUpdate;
    }

    public async Task DeleteCookingStepAsync(Guid id)
    {
        var cookingStepToDelete = await _set.FindAsync(id);
        if (cookingStepToDelete == null)
        {
            return;
        }

        _set.Remove(cookingStepToDelete);
        await _context.SaveChangesAsync();
    }
}