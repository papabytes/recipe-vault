using MediatR;
using Newtonsoft.Json;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.Create;

public class CreateRecipeRequest : IRequest<RecipeDto>
{
    [JsonProperty("name")] 
    public string Name { get; set; }

    [JsonProperty("ingredients")]
    public IEnumerable<IngredientDto> Ingredients { get; set; }

    [JsonProperty("steps")]
    public IEnumerable<CookingStepDto> Steps { get; set; }
}