using ToDoAppNTier.DataAccess.Interfaces;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.DataAccess.UnitOfWork
{
    // Unit Of Work design architecture
    public interface IUow
    {
        Task SaveChanges();

        IRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}
