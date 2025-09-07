using Lachi.Data.Entities.UserStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lachi.Data.Contexts.Configs.UserStuff
{
    public class UserChannelConfigs : IEntityTypeConfiguration<UserChannel>
    {
        public void Configure(EntityTypeBuilder<UserChannel> builder)
        {
            builder.ConfigureBaseEntity<UserChannel>();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            builder.Property(c => c.ProfileImagePath)
                .HasMaxLength(250);

            builder.Property(c => c.BannerImagePath)
                .HasMaxLength(250);

            builder.HasOne(c => c.User)
                .WithOne(u => u.UserChannel)
                .HasForeignKey<UserChannel>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(c => c.Videos)
                .WithOne(v => v.UserChannel)
                .HasForeignKey(v => v.UserChannelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Playlists)
                .WithOne(p => p.UserChannel)
                .HasForeignKey(p => p.UserChannelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
