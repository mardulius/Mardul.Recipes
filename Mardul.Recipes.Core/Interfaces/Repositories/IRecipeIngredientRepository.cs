using Mardul.Recipes.Core.Entities;


namespace Mardul.Recipes.Core.Interfaces.Repositories
{
    public interface IRecipeIngredientRepository : IGenericRepository<RecipeIngredient>
    {
        Task AddRange(IEnumerable<RecipeIngredient> recipeIngredients);
    }
}
