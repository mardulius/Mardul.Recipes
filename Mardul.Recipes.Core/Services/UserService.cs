using AutoMapper;
using Mardul.Recipes.Core.Dto.Accounts;
using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Mardul.Recipes.Core.Interfaces.Services;

namespace Mardul.Recipes.Core.Services
{
    public class UserService : IUserService
    {
        #region DI

        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IUnitOfWorkService _unitOfWorkService;

        public UserService(ITokenService tokenService, IUserRepository userRepository, IMapper mapper,
            IPasswordHashService passwordHashService,
            IUnitOfWorkService unitOfWorkService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHashService = passwordHashService; 
            _unitOfWorkService = unitOfWorkService;
        }

        #endregion

        public Task<bool> Login(LoginRequestDto request)
        {
            //var token = _tokenService.Generate(user);
            throw new NotImplementedException();
        }

        public async Task<bool> Register(RegisterRequestDto request)
        {
            var createUser = _mapper.Map<User>(request);
            
            createUser.Password = _passwordHashService.Generate(request.Password);

            await _userRepository.Add(createUser);
            await _unitOfWorkService.SaveChangesAsync();

            return true;
        }

      
    }
}
