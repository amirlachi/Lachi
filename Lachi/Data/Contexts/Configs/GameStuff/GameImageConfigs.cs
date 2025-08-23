using Lachi.Data.Entities.GameStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace Lachi.Data.Contexts.Configs.GameStuff
{
    public class GameImageConfigs : IEntityTypeConfiguration<GameImage>
    {
        public void Configure(EntityTypeBuilder<GameImage> builder)
        {
            builder.ConfigureBaseEntity();

            builder.Property(i => i.Path)
                .IsRequired();
        }
    }
}
