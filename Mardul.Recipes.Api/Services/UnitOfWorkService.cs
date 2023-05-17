using Mardul.Recipes.Data.DbContexts;
using Mardul.Recipes.Data.Repositories;

namespace Mardul.Recipes.Api.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly AppDbContext _appDbContext;
        public IRecipeRepository RecipeRepository { get; set; }
        public IRecipeIngredientRepository RecipeIngredientRepository { get; set; }

        public UnitOfWorkService(AppDbContext appDbContext, IRecipeRepository recipeRepository, IRecipeIngredientRepository recipeIngredientRepository)
        {
            _appDbContext = appDbContext;
            RecipeRepository = recipeRepository;
            RecipeIngredientRepository = recipeIngredientRepository;
        }
        public async Task<int> Save()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
