
using Mardul.Recipes.Core.Dto.Accounts;

namespace Mardul.Recipes.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task Login(LoginRequestDto request);
        Task Register(RegisterRequestDto request);
    }
}
