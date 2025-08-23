using Lachi.Data.Entities.VideoStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.VideoStuff
{
    public class VideoCommentConfigs : IEntityTypeConfiguration<VideoComment>
    {
        public void Configure(EntityTypeBuilder<VideoComment> builder)
        {
            builder.Property(vc => vc.Body)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne(vc => vc.Owner)
                .WithMany(u => u.VideoComments)
                .HasForeignKey(vc => vc.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
