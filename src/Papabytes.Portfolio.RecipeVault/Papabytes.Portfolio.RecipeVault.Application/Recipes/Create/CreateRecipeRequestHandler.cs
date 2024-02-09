using AutoMapper;
using MediatR;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;
using Papabytes.Portfolio.RecipeVault.Domain.Entities;
using Papabytes.Portfolio.RecipeVault.Domain.Repositories;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.Create;

public class CreateRecipeRequestHandler : IRequestHandler<CreateRecipeRequest, RecipeDto>
{
    private readonly IMapper _mapper;
    private readonly IRecipeRepository _recipeRepository;

    public CreateRecipeRequestHandler(IMapper mapper, IRecipeRepository recipeRepository)
    {
        _mapper = mapper;
        _recipeRepository = recipeRepository;
    }
    
    public async Task<RecipeDto> Handle(CreateRecipeRequest request, CancellationToken cancellationToken)
    {
        var recipeToCreate = new Recipe
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Ingredients = request.Ingredients.Select(i => new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = i.Name,
                Quantity = i.Quantity,
                Unit = i.Unit
            }),
            Steps = request.Steps.Select((step, index) =>
                new CookingStep
                {
                    Order = index + 1,
                    Description = step.Description,
                })
        };

        var result = await _recipeRepository.CreateAsync(recipeToCreate);
        var recipeDto = _mapper.Map<RecipeDto>(result);

        return recipeDto;
    }
}