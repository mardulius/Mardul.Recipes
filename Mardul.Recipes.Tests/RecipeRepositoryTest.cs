using Mardul.Recipes.Data.Entities;
using Mardul.Recipes.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mardul.Recipes.Tests
{
    public class RecipeRepositoryTest
    {

        [Fact]
        public void GetAllAsync_ListRecipes()
        {
            //arrange
            var mock = new Mock<IRecipeRepository>();


            mock.Setup(m => m.GetAll().Result).Returns(GetTestRecipes());

            //act
            var result = mock.Object.GetAll().Result;

            //assert
            Assert.Equal(result.ToList().Count, GetTestRecipes().ToList().Count);
            Assert.NotEmpty(result);
            Assert.IsType<List<Recipe>>(result);

        }

        [Fact]
        public void GetAsync_Recipe()
        {
            //arrange
            var mock = new Mock<IRecipeRepository>();
            var recipeId = 1;
            mock.Setup(m => m.GetById(recipeId).Result)
            .Returns(GetTestRecipes()
            .FirstOrDefault(r => r.Id == recipeId));

            //act
            var result = mock.Object.GetById(recipeId).Result;

            //assert
            Assert.NotNull(result);
            Assert.IsType<Recipe>(result);
            Assert.Equal(result.Id, GetTestRecipes().FirstOrDefault(r => r.Id == recipeId).Id);

        }

        private IEnumerable<Recipe> GetTestRecipes()
        {
            IEnumerable<Recipe> recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1,
                    DateCreate = DateTime.Parse("2023-05-16 17:16:30.9646917"),
                    Name = "Test"
                },
                new Recipe()
                {
                    Id = 2,
                    DateCreate = DateTime.Parse("2023-05-14 11:12:40.9643917"),
                    Name = "Test2"
                },
            };

            return recipes;
        }
    }
}
