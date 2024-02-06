namespace Papabytes.Portfolio.RecipeVault.Domain.Entities;

public class Recipe
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Ingredient> Ingredients { get; set; }
    public IEnumerable<CookingStep> Steps { get; set; }
}