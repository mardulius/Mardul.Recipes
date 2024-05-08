using Mardul.Recipes.Core.Entities;


namespace Mardul.Recipes.Core.Interfaces.Repositories
{
    public interface IRecipeIngredientRepository : IGenericRepository<RecipeIngredientEntity>
    {
        Task AddRange(IEnumerable<RecipeIngredientEntity> recipeIngredients);
    }
}
