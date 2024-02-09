using MediatR;
using Newtonsoft.Json;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.GetById;

public class GetRecipeByIdRequest : IRequest<RecipeDto?>
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    public GetRecipeByIdRequest(Guid id)
    {
        Id = id;
    }
}