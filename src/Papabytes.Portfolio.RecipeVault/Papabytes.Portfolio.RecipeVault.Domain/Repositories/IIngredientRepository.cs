using Papabytes.Portfolio.RecipeVault.Domain.Entities;

namespace Papabytes.Portfolio.RecipeVault.Domain.Repositories;

public interface IIngredientRepository
{
    public Task<Ingredient?> GetByIdAsync(Guid id);
    public Task<IEnumerable<Ingredient>> GetIngredientsByRecipeAsync(Guid recipeId);
    public Task<Ingredient> CreateIngredientASync(Ingredient ingredient);
    public Task<Ingredient?> UpdateIngredientAsync(Guid id, Ingredient ingredient);
    public Task DeleteByIdAsync(Guid id);
}