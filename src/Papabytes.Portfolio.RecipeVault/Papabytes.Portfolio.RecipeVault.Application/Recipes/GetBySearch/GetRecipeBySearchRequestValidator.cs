using FluentValidation;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.GetBySearch;

public class GetRecipeBySearchRequestValidator : AbstractValidator<GetRecipeBySearchRequest>
{
    public GetRecipeBySearchRequestValidator()
    {
        RuleFor(s => s.Search)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);
    }
}