namespace Papabytes.Portfolio.RecipeVault.Domain.Entities;

public class CookingStep
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    
    public Recipe Recipe { get; set; }
}