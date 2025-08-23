using Lachi.Data.Entities.GameStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.GameStuff
{
    public class GameStudioConfigs : IEntityTypeConfiguration<GameStudio>
    {
        public void Configure(EntityTypeBuilder<GameStudio> builder)
        {
            builder.ConfigureBaseEntity();

            builder.Property(gs => gs.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(gs => gs.Description)
                .HasMaxLength(2000);

            builder.Property(gs => gs.FoundedYear)
                .IsRequired();
        }
    }
}
