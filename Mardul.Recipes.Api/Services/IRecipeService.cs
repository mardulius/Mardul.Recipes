using Mardul.Recipes.Api.Dto;
using Mardul.Recipes.Data.Entities;

namespace Mardul.Recipes.Api.Services
{
    public interface IRecipeService
    {
        Task<bool> Add(RecipeDto recipe);
        Task<RecipeDto> GetById(int id);
        Task<IEnumerable<RecipeDto>> GetAll();
    }
}
