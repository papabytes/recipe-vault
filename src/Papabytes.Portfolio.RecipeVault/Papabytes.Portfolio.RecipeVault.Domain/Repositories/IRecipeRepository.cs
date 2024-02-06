using Papabytes.Portfolio.RecipeVault.Domain.Entities;

namespace Papabytes.Portfolio.RecipeVault.Domain.Repositories;

public interface IRecipeRepository
{
    Task<Recipe?> GetByIdAsync(Guid id);
    Task<IEnumerable<Recipe>> SearchAsync(string search);
    Task<Recipe> CreateAsync(Recipe recipe);
    Task<Recipe?> UpdateAsync(Guid id, Recipe recipe);
    Task DeleteAsync(Guid id);
}