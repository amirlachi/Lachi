using Lachi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs
{
    public static class BaseEntityConfigs
    {
        public static void ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class,IBaseEntity
        {
            builder.HasOne(b => b.CreatedBy)
                .WithMany()
                .HasForeignKey(b => b.CreatedById);

            builder.HasOne(b => b.UpdatedBy)
                .WithMany()
                .HasForeignKey(b => b.UpdatedById);

            builder.HasOne(b => b.RemovedBy)
                .WithMany()
                .HasForeignKey(b => b.RemovedById);
        }
    }


}
