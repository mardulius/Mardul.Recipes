using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Mardul.Recipes.Infrastructure.Repositories
{
    public class RecipeIngredientRepository : GenericRepository<RecipeIngredientEntity>, IRecipeIngredientRepository
    {
        public RecipeIngredientRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddRange(IEnumerable<RecipeIngredientEntity> recipeIngredients)
        {
           await _dbContext.AddRangeAsync(recipeIngredients);
        }
    }
}
