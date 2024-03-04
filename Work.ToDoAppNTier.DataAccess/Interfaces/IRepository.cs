using System.Linq.Expressions;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.DataAccess.Interfaces
{
    // repository design pattern for database CRUD operations
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        
        //Task<T> GetById(object id);
        Task<T> Find(object id);
        
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);

        IQueryable<T> GetQuery();

        Task Create(T entity);
        
        // void Update(T entity);
        void Update(T entity, T unchanged);

        // void Remove(T entity);
        // void Remove(object id);
        void Remove(T entity);
    }
}
