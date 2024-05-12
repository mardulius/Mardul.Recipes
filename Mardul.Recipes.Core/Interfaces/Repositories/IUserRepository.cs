

using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Enums;

namespace Mardul.Recipes.Core.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        Task<UserEntity> GetByEmail(string email);
        Task<UserEntity> GetByNickName(string? name);
        Task<IEnumerable<Permission>> GetPermissionsAsync(int userId);
    }
}
