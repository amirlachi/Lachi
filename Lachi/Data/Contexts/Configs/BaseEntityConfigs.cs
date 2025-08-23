using Lachi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs
{
    public class BaseEntityConfigs : IEntityTypeConfiguration<IBaseEntity>
    {
        public void Configure(EntityTypeBuilder<IBaseEntity> builder)
        {
            builder.HasOne(b => b.CreatedBy)
                .WithOne(u => u)
                .HasForeignKey<IBaseEntity>(b => b.CreatedById);

            builder.HasOne(b => b.UpdatedBy)
                .WithOne(u => u)
                .HasForeignKey<IBaseEntity>(b => b.UpdatedById);

            builder.HasOne(b => b.RemovedBy)
                .WithOne(u => u)
                .HasForeignKey<IBaseEntity>(b => b.RemovedById);
        }

        public static void BaseConfigs<TEntity>(EntityTypeBuilder<IBaseEntity> builder) where TEntity : IBaseEntity
        {
            builder.HasOne(b => b.CreatedBy)
                .WithOne(u => u)
                .HasForeignKey<IBaseEntity>(b => b.CreatedById);

            builder.HasOne(b => b.UpdatedBy)
                .WithOne(u => u)
                .HasForeignKey<IBaseEntity>(b => b.UpdatedById);

            builder.HasOne(b => b.RemovedBy)
                .WithOne(u => u)
                .HasForeignKey<IBaseEntity>(b => b.RemovedById);
        }
    }


}
