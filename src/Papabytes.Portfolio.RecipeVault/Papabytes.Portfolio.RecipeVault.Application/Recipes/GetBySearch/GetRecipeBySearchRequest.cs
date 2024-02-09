using MediatR;
using Newtonsoft.Json;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.GetBySearch;

public class GetRecipeBySearchRequest : IRequest<IEnumerable<RecipeDto>>
{
    [JsonProperty("search")] 
    public string Search { get; set; }
}