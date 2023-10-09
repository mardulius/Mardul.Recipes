using Mardul.Recipes.Core.Dto;
using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mardul.Recipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        #region DI
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public TokenController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }
        #endregion

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(TokenDto token)
        {
            if (token is null)
                return BadRequest();

            string accessToken = token.AccessToken;
            string refreshToken = token.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var name = principal.Identity.Name;
            User user = await _userService.GetByEmail(name);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest();

            var newAccessToken = _tokenService.Generate(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;

            await _userService.Update(user);

            return Ok(new TokenDto(newAccessToken, newRefreshToken));
        }


    }
}
