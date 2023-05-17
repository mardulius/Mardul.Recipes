using Mardul.Recipes.Api.Dto;
using Mardul.Recipes.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mardul.Recipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        #region DI

        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        #endregion


        [HttpGet]
        [Route("All")]
        public async Task<IEnumerable<RecipeDto>> Get()
        {
            return await _recipeService.GetAll();
        }

    }
}
