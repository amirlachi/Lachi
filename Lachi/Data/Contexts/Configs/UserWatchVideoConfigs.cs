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
        }
    }
}
