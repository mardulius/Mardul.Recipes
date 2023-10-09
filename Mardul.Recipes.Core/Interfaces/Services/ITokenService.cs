using Mardul.Recipes.Core.Entities;


namespace Mardul.Recipes.Core.Interfaces.Services
{
    public interface ITokenService
    {
        string Generate(User user);
        string GenerateRefreshToken();
    }
}
