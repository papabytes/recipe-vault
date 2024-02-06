using AutoMapper;
using MediatR;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;
using Papabytes.Portfolio.RecipeVault.Domain.Repositories;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.GetById;

public class GetRecipeByIdRequestHandler : IRequestHandler<GetRecipeByIdRequest, RecipeDto?>
{
    private readonly IMapper _mapper;
    private readonly IRecipeRepository _recipeRepository;

    public GetRecipeByIdRequestHandler(IMapper mapper, IRecipeRepository recipeRepository)
    {
        _mapper = mapper;
        _recipeRepository = recipeRepository;
    }
    
    public async Task<RecipeDto?> Handle(GetRecipeByIdRequest request, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetByIdAsync(request.Id);
        return _mapper.Map<RecipeDto?>(recipe);
    }
}