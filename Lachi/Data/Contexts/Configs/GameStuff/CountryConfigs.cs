using Lachi.Data.Entities;
using Lachi.Data.Entities.GameStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.GameStuff
{
    public class CountryConfigs : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ConfigureBaseEntity();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
