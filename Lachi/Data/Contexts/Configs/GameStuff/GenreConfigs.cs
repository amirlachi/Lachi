using Lachi.Data.Entities.GameStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.GameStuff
{
    public class GenreConfigs : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
