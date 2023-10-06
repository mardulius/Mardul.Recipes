using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Interfaces.Repositories;


namespace Mardul.Recipes.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
