using AutoMapper;
using Mardul.Recipes.Core.Dto;
using Mardul.Recipes.Core.Entities;

namespace Mardul.Recipes.Core.Services
{
    public class RecipeMappingProfile : Profile
    {
        public RecipeMappingProfile()
        {
            CreateMap<RecipeDto, RecipeEntity>().ReverseMap();
            CreateMap<RecipeIngredientDto, RecipeIngredientEntity>().ReverseMap();
            CreateMap<CreateRecipeDto, RecipeEntity>();
            CreateMap<CreateRecipeIngredientDto, RecipeIngredientEntity>();
        }
    }
}

