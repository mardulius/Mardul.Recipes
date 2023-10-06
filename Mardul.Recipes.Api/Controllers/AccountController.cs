using Mardul.Recipes.Core.Dto.Accounts;
using Mardul.Recipes.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mardul.Recipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        #region DI

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        /// <summary>
        /// register new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Register(request);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            await _userService.Login(request);

            return Ok();
        }
    }
}
