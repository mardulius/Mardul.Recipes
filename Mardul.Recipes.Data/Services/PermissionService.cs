using Mardul.Recipes.Core.Enums;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Mardul.Recipes.Core.Interfaces.Services;

namespace Mardul.Recipes.Infrastructure.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUserRepository _userRepository;

        public PermissionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Permission>> GetPermissionsAsync(int userId)
        {
            return await _userRepository.GetPermissionsAsync(userId);
        }
    }
}
