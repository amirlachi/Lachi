using Lachi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs
{
    public class UserWatchVideoConfigs : IEntityTypeConfiguration<UserWatchVideo>
    {
        public void Configure(EntityTypeBuilder<UserWatchVideo> builder)
        {
            builder.HasKey(uw => new { uw.UserId, uw.VideoId });

            builder.HasOne(uw => uw.Video)
                .WithMany(v => v.UserWatches)
                .HasForeignKey(uw => uw.VideoId);

            builder.HasOne(uw => uw.User)
                .WithMany(u => u.WatchedVideos)
                .HasForeignKey(uw => uw.UserId);
        }
    }
}
