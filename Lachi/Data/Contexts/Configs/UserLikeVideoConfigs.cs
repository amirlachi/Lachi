using Lachi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs
{
    public class UserLikeVideoConfigs : IEntityTypeConfiguration<UserLikeVideo>
    {
        public void Configure(EntityTypeBuilder<UserLikeVideo> builder)
        {
            builder.HasKey(ul => new { ul.VideoId, ul.UserId });

            builder.HasOne(ul => ul.Video)
                .WithMany(v => v.UserLikes)
                .HasForeignKey(ul => ul.VideoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ul => ul.User)
                .WithMany(u => u.LikedVideos)
                .HasForeignKey(ul => ul.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
