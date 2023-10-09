
using Mardul.Recipes.Core.Dto;
using Mardul.Recipes.Core.Dto.Accounts;
using Mardul.Recipes.Core.Entities;

namespace Mardul.Recipes.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetByEmail(string value);
        Task<User> GetByNickName(string? name);
        Task<TokenDto> Login(LoginRequestDto request);
        Task<bool> Register(RegisterRequestDto request);
        Task Update(User user);
    }
}
