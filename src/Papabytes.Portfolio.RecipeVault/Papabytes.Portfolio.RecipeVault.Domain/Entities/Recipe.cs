namespace Papabytes.Portfolio.RecipeVault.Domain.Entities;

public class Recipe
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IList<Ingredient> Ingredients { get; set; }
    public IList<CookingStep> Steps { get; set; }
}