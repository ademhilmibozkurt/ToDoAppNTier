
using Microsoft.EntityFrameworkCore;
using ToDoAppNTier.DataAccess.Contexts;
using ToDoAppNTier.DataAccess.Interfaces;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.DataAccess.Repositories
{
    // repository design pattern for database CRUD operations
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TodoContext _context;

        public Repository(TodoContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(System.Linq.Expressions.Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(filter) : await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> Find(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        //public void Remove(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //}

        public void Remove(T entity)
        {
            // var deleted = _context.Set<T>().Find(id);

            // common layer using
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity, T unchanged)
        {
            // _context.Set<T>().Update(entity);

            // using base entity class
            // var updated = _context.Set<T>().Find(entity.Id);
            
            _context.Entry(unchanged).CurrentValues.SetValues(entity);

        }
    }
}
