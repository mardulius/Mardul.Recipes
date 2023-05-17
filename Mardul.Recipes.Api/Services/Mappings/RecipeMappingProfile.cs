using AutoMapper;
using Mardul.Recipes.Api.Dto;
using Mardul.Recipes.Data.Entities;

namespace Mardul.Recipes.Api.Services.Mappings
{
    public class RecipeMappingProfile : Profile
    {
        public RecipeMappingProfile()
        {
            CreateMap<RecipeDto, Recipe>().ReverseMap();
            CreateMap<RecipeIngredientDto, RecipeIngredient>().ReverseMap();
        }
    }
}

