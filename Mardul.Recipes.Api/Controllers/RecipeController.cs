﻿using Mardul.Recipes.Core.Dto;
using Mardul.Recipes.Core.Enums;
using Mardul.Recipes.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeService.GetAll();

            return Ok(recipes);
        }

        [Authorize(Policy = nameof(Permission.Create))]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] CreateRecipeDto recipe)
        {
            await _recipeService.Add(recipe);

            return Ok();
        }
        
        [Authorize(Policy = nameof(Permission.Read))]
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var recipe = await _recipeService.GetById(id);

            return Ok(recipe);
        }
    }
}
