

using Mardul.Recipes.Core.Dto.Accounts;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Mardul.Recipes.Core.Interfaces.Services;

namespace Mardul.Recipes.Core.Services
{
    public class UserService : IUserService
    {
        #region DI

        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public UserService(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        #endregion

        public Task Login(LoginRequestDto request)
        {
            //var token = _tokenService.Generate(user);
            throw new NotImplementedException();
        }

        public Task Register(RegisterRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
