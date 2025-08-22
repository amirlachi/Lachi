using Lachi.Data.Entities.GameStuff;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.GameStuff
{
    public class GameConfigs : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(g => g.TrailerVideoPath)
                .IsRequired();
        }
    }
}
