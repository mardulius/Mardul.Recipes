using Mardul.Recipes.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Mardul.Recipes.Data.Repositories
{
    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
