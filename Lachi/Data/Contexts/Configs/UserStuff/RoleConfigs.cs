using Lachi.Data.Entities.UserStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.UserStuff
{
    public class RoleConfigs : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ConfigureBaseEntity();

            builder.Property(r => r.Description)
                .HasMaxLength(500);
        }
    }
}
