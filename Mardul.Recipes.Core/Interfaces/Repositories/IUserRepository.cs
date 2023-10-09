

using Mardul.Recipes.Core.Entities;

namespace Mardul.Recipes.Core.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByNickName(string? name);
    }
}
