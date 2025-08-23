using Lachi.Data.Entities.VideoStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.VideoStuff
{
    public class VideoConfigs : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(v => v.Description)
                .HasMaxLength(2000);

            builder.HasOne(v => v.Owner)
                  .WithMany(u => u.Videos)
                  .HasForeignKey(v => v.OwnerId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.FavoriteByUsers)
                  .WithMany(u => u.FavoriteVideos);
        }
    }
}
