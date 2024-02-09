using AutoMapper;
using MediatR;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;
using Papabytes.Portfolio.RecipeVault.Domain.Repositories;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.GetBySearch;

public class GetRecipeBySearchRequestHandler : IRequestHandler<GetRecipeBySearchRequest, IEnumerable<RecipeDto>>
{
    private readonly IMapper _mapper;
    private readonly IRecipeRepository _recipeRepository;

    public GetRecipeBySearchRequestHandler(IMapper mapper, IRecipeRepository recipeRepository)
    {
        _mapper = mapper;
        _recipeRepository = recipeRepository;
    }
    
    public async Task<IEnumerable<RecipeDto>> Handle(GetRecipeBySearchRequest request, CancellationToken cancellationToken)
    {
        var repoSearchResults = await _recipeRepository.SearchAsync(request.Search);

        return repoSearchResults.Any() ? new List<RecipeDto>() : _mapper.Map<IEnumerable<RecipeDto>>(repoSearchResults);
    }
}