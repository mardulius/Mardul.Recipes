using Mardul.Recipes.Core.Entities;

namespace Mardul.Recipes.Core.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
            Task Add(T entity);
            Task<T> GetById(int id);
            Task Remove(T entity);
            Task<IEnumerable<T>> GetAll();
    }
}
