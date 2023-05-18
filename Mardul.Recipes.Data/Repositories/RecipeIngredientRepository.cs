using Mardul.Recipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mardul.Recipes.Data.Repositories
{
    public class RecipeIngredientRepository : GenericRepository<RecipeIngredient>, IRecipeIngredientRepository
    {
        public RecipeIngredientRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddRange(IEnumerable<RecipeIngredient> recipeIngredients)
        {
           await _dbContext.AddRangeAsync(recipeIngredients);
        }
    }
}
