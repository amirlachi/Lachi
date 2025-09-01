using Lachi.Data.Entities.UserStuff;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.UserStuff
{
    public class UserConfigs : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ConfigureBaseEntity();


            builder.Property(x => x.FirstName)
                .HasMaxLength(20);

            builder.Property(x => x.LastName)
                .HasMaxLength(20);

            builder.Property(x => x.Bio)
                .HasMaxLength(180);
        }
    }
}
