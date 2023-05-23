using Mardul.Recipes.Data.DbContexts;
using Mardul.Recipes.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mardul.Recipes.Api.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly DbContext _dbContext;
        public IRecipeRepository RecipeRepository { get; set; }
        public IRecipeIngredientRepository RecipeIngredientRepository { get; set; }

        public UnitOfWorkService(DbContext dbContext, IRecipeRepository recipeRepository, IRecipeIngredientRepository recipeIngredientRepository)
        {
            _dbContext = dbContext;
            RecipeRepository = recipeRepository;
            RecipeIngredientRepository = recipeIngredientRepository;
        }
        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
