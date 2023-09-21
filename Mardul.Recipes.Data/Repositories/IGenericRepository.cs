using Mardul.Recipes.Data.Entities;

namespace Mardul.Recipes.Data.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
            Task Add(T entity);
            Task<T> GetById(int id);
            Task Remove(T entity);
            Task<IEnumerable<T>> GetAll();
    }
}
