using AutoMapper;
using Mardul.Recipes.Core.Dto;
using Mardul.Recipes.Core.Dto.Accounts;
using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Mardul.Recipes.Core.Interfaces.Services;
using System.Security.Claims;

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

        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task<UserEntity> GetByNickName(string? name)
        {
            return await _userRepository.GetByNickName(name);
        }

        #endregion

        public async Task<TokenDto> Login(LoginRequestDto request)
        {
            var user = await _userRepository.GetByEmail(request.Email);

            if (user != null)
            {
                var result = _passwordHashService.Validate(request.Password, user.Password);

                if (result is true)
                {
                    var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    var token = _tokenService.Generate(claims);
                    user.RefreshToken = _tokenService.GenerateRefreshToken();
                    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                    user.Updated = DateTime.UtcNow;

                    await _userRepository.Update(user);

                    await _unitOfWorkService.SaveChangesAsync();

                    return new TokenDto(token, user.RefreshToken);
                }
            }
            return null;
        }

        public async Task<bool> Register(RegisterRequestDto request)
        {
            var createUser = _mapper.Map<UserEntity>(request);

            createUser.Password = _passwordHashService.Generate(request.Password);

            await _userRepository.Add(createUser);
            await _unitOfWorkService.SaveChangesAsync();

            return true;
        }

        public async Task Update(UserEntity user)
        {
            await _userRepository.Update(user);
            await _unitOfWorkService.SaveChangesAsync();
        }
    }
}
