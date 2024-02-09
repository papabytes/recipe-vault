using MediatR;
using Microsoft.AspNetCore.Mvc;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;
using Papabytes.Portfolio.RecipeVault.Application.Recipes.Create;
using Papabytes.Portfolio.RecipeVault.Application.Recipes.GetById;
using Papabytes.Portfolio.RecipeVault.Application.Recipes.GetBySearch;

namespace Papabytes.Portfolio.RecipeVault.API.Controllers;

[Route("api/recipes")]
public class RecipesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecipesController(IMediator mediator)
    {
        _mediator = mediator;
    }

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesBySearchAsync(
        [FromQuery] GetRecipeBySearchRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<RecipeDto>> CreateRecipeAsync([FromBody] CreateRecipeRequest request)
    {
        var result = await _mediator.Send(request);
        return Created($"/api/recipes/{result.Id}", result);
    }
}