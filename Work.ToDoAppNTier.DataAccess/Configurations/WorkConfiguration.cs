using Microsoft.EntityFrameworkCore;
using ToDoAppNTier.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoAppNTier.DataAccess.Configurations
{
    // Work class property validation settings
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Definition).IsRequired(true);
            builder.Property(x => x.Definition).HasMaxLength(300);

            builder.Property(x => x.IsCompleted).IsRequired(true);
        }
    }
}
