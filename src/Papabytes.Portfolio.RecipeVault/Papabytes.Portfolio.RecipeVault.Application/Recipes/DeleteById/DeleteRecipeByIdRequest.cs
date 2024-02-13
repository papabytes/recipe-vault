using MediatR;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.DeleteById;

public class DeleteRecipeByIdRequest : IRequest
{
    public Guid RecipeId { get; set; }
}