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
        }
    }
}
