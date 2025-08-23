using Lachi.Data.Entities.VideoStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.VideoStuff
{
    public class VideoStatusConfigs : IEntityTypeConfiguration<VideoStatus>
    {
        public void Configure(EntityTypeBuilder<VideoStatus> builder)
        {
            builder.ConfigureBaseEntity();

            builder.Property(vs => vs.Status)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
