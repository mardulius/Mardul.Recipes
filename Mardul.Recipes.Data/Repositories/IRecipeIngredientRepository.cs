﻿using Mardul.Recipes.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mardul.Recipes.Data.Repositories
{
    public interface IRecipeIngredientRepository : IGenericRepository<RecipeIngredient>
    {
        Task AddRange(IEnumerable<RecipeIngredient> recipeIngredients);
    }
}
