namespace Papabytes.Portfolio.RecipeVault.Application.Common.Models;

public class RecipeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<IngredientDto> Ingredients { get; set; }
    public IEnumerable<CookingStepDto> Steps { get; set; }
}