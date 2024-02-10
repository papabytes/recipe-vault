using MediatR;
using Microsoft.AspNetCore.Mvc;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;
using Papabytes.Portfolio.RecipeVault.Application.Recipes.Create;
using Papabytes.Portfolio.RecipeVault.Application.Recipes.GetById;
using Papabytes.Portfolio.RecipeVault.Application.Recipes.GetBySearch;

namespace Papabytes.Portfolio.RecipeVault.API.Controllers;

/// <summary>
///     A set of REST endpoints related to Recipes
/// </summary>
[Route("api/recipes")]
public class RecipesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecipesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    ///     Returns a recipe from its unique identifier
    /// </summary>
    /// <param name="id">Recipe's unique identifier following UUIDv4 standard</param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RecipeDto>> GetRecipeByIdAsync(Guid id)
    {
        var request = new GetRecipeByIdRequest(id);
        var result = await _mediator.Send(request);

        if (result != null)
        {
            return Ok(result);
        }

        return NotFound($"recipe with id {id} does not exist.");
    }

    /// <summary>
    ///     Returns a list of recipes that match the search
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesBySearchAsync(
        GetRecipeBySearchRequest search)
    {
        var result = await _mediator.Send(search);
        return Ok(result);
    }

    /// <summary>
    ///     Creates a new recipe
    /// </summary>
    /// <param name="request">The recipe's etails</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<RecipeDto>> CreateRecipeAsync([FromBody] CreateRecipeRequest request)
    {
        var result = await _mediator.Send(request);
        return Created($"/api/recipes/{result.Id}", result);
    }
}