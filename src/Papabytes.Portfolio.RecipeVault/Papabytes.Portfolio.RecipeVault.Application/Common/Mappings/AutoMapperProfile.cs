using AutoMapper;
using Papabytes.Portfolio.RecipeVault.Application.Common.Models;
using Papabytes.Portfolio.RecipeVault.Domain.Entities;

namespace Papabytes.Portfolio.RecipeVault.Application.Common.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Ingredient, IngredientDto>();

        CreateMap<CookingStep, CookingStepDto>();

        CreateMap<Recipe, RecipeDto>();
    }
}