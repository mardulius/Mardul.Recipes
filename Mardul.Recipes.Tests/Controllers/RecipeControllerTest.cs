using FakeItEasy;
using FluentAssertions;
using Mardul.Recipes.Api.Controllers;
using Mardul.Recipes.Api.Dto;
using Mardul.Recipes.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mardul.Recipes.Tests.Controllers
{
    public class RecipeControllerTest
    {
        private IRecipeService _recipeService;
        private RecipeController _recipeController;

        public RecipeControllerTest()
        {
            _recipeService = A.Fake<IRecipeService>();
            _recipeController = new RecipeController(_recipeService);
        }


        [Fact]
        public async Task RecipeController_GetAll_ReturnOk()
        {
            var recipes = A.Fake<IEnumerable<RecipeDto>>();
            A.CallTo(() => _recipeService.GetAll()).Returns(recipes);
           
            var result = await _recipeController.GetAll();

            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public async Task RecipeController_Add_ReturnOk()
        {
            var recipe = A.Fake<RecipeDto>();
            A.CallTo(() => _recipeService.Add(recipe)).Returns(true);

            var result = await _recipeController.Add(recipe);

            result.Should().NotBeNull();
            result.Should().BeOfType<OkResult>();
        }

    }
}
