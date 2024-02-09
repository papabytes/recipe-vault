using FluentValidation;

namespace Papabytes.Portfolio.RecipeVault.Application.Recipes.Create;

public class CreateRecipeRequestValidator : AbstractValidator<CreateRecipeRequest>
{
    public CreateRecipeRequestValidator()
    {
        RuleFor(crr => crr.Name)
            .MinimumLength(3)
            .MaximumLength(120)
            .NotNull()
            .NotEmpty();

        RuleFor(crr => crr.Ingredients)
            .NotEmpty();
        
        RuleFor(crr => crr.Steps)
            .NotEmpty();
    }
}