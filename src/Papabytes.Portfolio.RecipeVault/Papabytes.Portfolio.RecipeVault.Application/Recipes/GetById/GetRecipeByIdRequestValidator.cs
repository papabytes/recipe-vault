using FluentValidation;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.GetById;

public class GetRecipeByIdRequestValidator : AbstractValidator<GetRecipeByIdRequest>
{
    public GetRecipeByIdRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Please provide a valid Id")
            .NotNull().WithMessage("Id must be provided");
    }
}