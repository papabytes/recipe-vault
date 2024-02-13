using MediatR;
using Papabytes.Portfolio.RecipeVault.Domain.Repositories;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.DeleteById;

public class DeleteRecipeByIdRequestHandler : IRequestHandler<DeleteRecipeByIdRequest>
{
    private readonly IRecipeRepository _recipeRepository;

    public DeleteRecipeByIdRequestHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public async Task Handle(DeleteRecipeByIdRequest request, CancellationToken cancellationToken)
    {
        await _recipeRepository.DeleteAsync(request.RecipeId);
    }
}