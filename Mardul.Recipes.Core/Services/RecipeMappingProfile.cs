using AutoMapper;
using Mardul.Recipes.Core.Dto;
using Mardul.Recipes.Core.Entities;

namespace Mardul.Recipes.Core.Services
{
    public class RecipeMappingProfile : Profile
    {
        public RecipeMappingProfile()
        {
            CreateMap<RecipeDto, Recipe>().ReverseMap();
            CreateMap<RecipeIngredientDto, RecipeIngredient>().ReverseMap();
            CreateMap<CreateRecipeDto, Recipe>();
            CreateMap<CreateRecipeIngredientDto, RecipeIngredient>();
        }
    }
}

