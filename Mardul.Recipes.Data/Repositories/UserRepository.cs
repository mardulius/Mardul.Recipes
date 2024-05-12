using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Enums;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mardul.Recipes.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserEntity?> GetByEmail(string email)
        {
            return await _dbContext
                .Set<UserEntity>()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<UserEntity?> GetByNickName(string name)
        {
            return await _dbContext
                .Set<UserEntity>()
                .FirstOrDefaultAsync(x => x.NickName == name);
        }

        public async Task<IEnumerable<Permission>> GetPermissionsAsync(int userId)
        {
            var result = await _dbContext
                 .Set<UserEntity>()
                 .AsNoTracking()
                 .Where(u => u.Id == userId)
                 .SelectMany(u => u.Roles.SelectMany(r => r.Permissions))
                 .ToListAsync();

            return result
                 .Select(p => (Permission)p.Id)
                 .ToHashSet();
        }
    }
}
