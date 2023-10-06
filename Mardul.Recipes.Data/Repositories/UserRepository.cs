using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mardul.Recipes.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
