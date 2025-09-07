using Lachi.Data.Entities.VideoStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.VideoStuff
{
    public class PlaylistConfigs : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ConfigureBaseEntity<Playlist>();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.HasOne(p => p.UserChannel)
                .WithMany(c => c.Playlists)
                .HasForeignKey(p => p.UserChannelId);
        }
    }
}
