using Papabytes.Portfolio.RecipeVault.Domain.Entities;

namespace Papabytes.Portfolio.RecipeVault.Domain.Repositories;

public interface ICookingStepRepository
{
    Task<IEnumerable<CookingStep>> GetCookingStepsByRecipeAsync(Guid recipeId);
    Task<CookingStep> CreateCookingStepAsync(CookingStep cookingStep);
    Task<CookingStep> UpdateCookingStepAsync(CookingStep cookingStep);
    Task DeleteCookingStepAsync(Guid id);
}