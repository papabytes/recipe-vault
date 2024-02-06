using Microsoft.EntityFrameworkCore;
using Papabytes.Portfolio.RecipeVault.Domain.Entities;
using Papabytes.Portfolio.RecipeVault.Domain.Repositories;

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
    }

    public Task<CookingStep> UpdateCookingStepAsync(CookingStep cookingStep)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCookingStepAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}