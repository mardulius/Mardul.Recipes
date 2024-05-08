

using Mardul.Recipes.Core.Entities;

namespace Mardul.Recipes.Core.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        Task<UserEntity> GetByEmail(string email);
        Task<UserEntity> GetByNickName(string? name);
    }
}
