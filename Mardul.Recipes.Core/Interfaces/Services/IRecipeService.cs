using Mardul.Recipes.Core.Dto;

namespace Mardul.Recipes.Core.Interfaces.Services
{
    public interface IRecipeService
    {
        Task<bool> Add(RecipeDto recipe);
        Task<RecipeDto> GetById(int id);
        Task<IEnumerable<RecipeDto>> GetAll();
    }
}
