using Lachi.Data.Entities.UserStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.UserStuff
{
    public class UserFollowConfigs : IEntityTypeConfiguration<UserFollow>
    {
        public void Configure(EntityTypeBuilder<UserFollow> builder)
        {
            builder.HasOne(uf => uf.Follower)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.FollowerId);

            builder.HasOne(uf => uf.Following)
                .WithMany(u => u.Followings)
                .HasForeignKey(uf => uf.FollowingId);
        }
    }
}
