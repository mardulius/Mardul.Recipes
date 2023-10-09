using Mardul.Recipes.Core.Entities;
using System.Security.Claims;

namespace Mardul.Recipes.Core.Interfaces.Services
{
    public interface ITokenService
    {
        string Generate(Claim[] userClaims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);
    }
}
