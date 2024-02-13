using MediatR;
using Microsoft.AspNetCore.Mvc;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.GetSteps;

public class GetRecipeStepsRequest : IRequest<IEnumerable<CookingStepDto>>
{
    [FromRoute(Name = "recipeId")]
    public Guid RecipeId { get; set; }
}