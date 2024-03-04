using ToDoAppNTier.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ToDoAppNTier.DataAccess.Configurations;

namespace ToDoAppNTier.DataAccess.Contexts
{
    // database data getter and setter interface
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
        }
        public DbSet<Work> Works{ get;set; }
    }
}     
