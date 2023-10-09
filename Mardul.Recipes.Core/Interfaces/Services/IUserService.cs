
using Mardul.Recipes.Core.Dto;
using Mardul.Recipes.Core.Dto.Accounts;

namespace Mardul.Recipes.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<TokenResponseDto> Login(LoginRequestDto request);
        Task<bool> Register(RegisterRequestDto request);
    }
}
