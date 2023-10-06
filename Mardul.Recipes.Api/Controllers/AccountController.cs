﻿using Mardul.Recipes.Core.Dto.Accounts;
using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mardul.Recipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        #region DI

        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AccountController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto)
        {

            if (!ModelState.IsValid)
            {

            }
        }
        
        
        
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] string email)
        {
            var user = new User { Email = email };

            var token = _tokenService.Generate(user);

            return Ok(token);
        }
    }
}
