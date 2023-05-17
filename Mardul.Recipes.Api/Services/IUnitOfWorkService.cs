using Mardul.Recipes.Data.Repositories;

namespace Mardul.Recipes.Api.Services
{
    public interface IUnitOfWorkService
    {
        Task<int> Save();
        IRecipeRepository RecipeRepository { get; set; }
        IRecipeIngredientRepository RecipeIngredientRepository { get; set; }

    }
}
