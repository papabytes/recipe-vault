using AutoMapper;
using MediatR;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;
using Papabytes.Portfolio.RecipeVault.Domain.Repositories;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.GetSteps;

public class GetRecipeStepsRequestHandler : IRequestHandler<GetRecipeStepsRequest, IEnumerable<CookingStepDto>>
{
    private readonly IMapper _mapper;
    private readonly ICookingStepRepository _cookingStepRepository;

    public GetRecipeStepsRequestHandler(IMapper mapper, ICookingStepRepository cookingStepRepository)
    {
        _mapper = mapper;
        _cookingStepRepository = cookingStepRepository;
    }
    
    public async Task<IEnumerable<CookingStepDto>> Handle(GetRecipeStepsRequest request, CancellationToken cancellationToken)
    {
        var cookingStepsFromDb = await _cookingStepRepository.GetCookingStepsByRecipeAsync(request.RecipeId);
        return _mapper.Map<IEnumerable<CookingStepDto>>(cookingStepsFromDb) ?? Array.Empty<CookingStepDto>();
    }
}