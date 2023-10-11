using Mardul.Recipes.Core.Dto;
using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Interfaces.Services;
using Mardul.Recipes.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
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

            var userEmail = principal.Identity.Name;
            User user = await _userService.GetByEmail(userEmail);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest();

            var userClaims = principal.Claims.ToArray();
            var newAccessToken = _tokenService.Generate(userClaims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;

            await _userService.Update(user);

            return Ok(new TokenDto(newAccessToken, newRefreshToken));
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var userEmail = User.Identity.Name;
            var user = await _userService.GetByEmail(userEmail);
            if (user == null) return BadRequest();

            user.RefreshToken = null;
            _userService.Update(user);

            return Ok("Токен отозван");
        }

    }
}
