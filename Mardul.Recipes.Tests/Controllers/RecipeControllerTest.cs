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

        public RecipeControllerTest()
        {
            _recipeService = A.Fake<IRecipeService>();
        }


        [Fact]
        public async Task RecipeController_GetAll_ReturnOk()
        {
            var recipes = A.Fake<IEnumerable<RecipeDto>>();
            A.CallTo(() => _recipeService.GetAll()).Returns(recipes);
            
            var controller = new RecipeController(_recipeService);

            var result = await controller.GetAll();

            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();

        }
    }
}
