using Lachi.Data.Contexts.Configs.GameStuff;
using Lachi.Data.Entities;
using Lachi.Data.Entities.GameStuff;
using Lachi.Data.Entities.UserStuff;
using Lachi.Data.Entities.VideoStuff;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lachi.Data.Contexts
{
    public class DataBaseContext : IdentityDbContext<User, Role, Guid>
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        #region GameStuff
        public DbSet<Game> Games { get; set; }
        public DbSet<GameStudio> GameStudios { get; set; }
        public DbSet<GameImage> GameImages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
        #endregion

        #region UserStuff
        public DbSet<UserFollow> UserFollows { get; set; }
        #endregion

        #region VideoStuff
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoComment> VideoComments { get; set; }
        public DbSet<VideoStatus> VideoStatuses { get; set; }
        #endregion

        #region Common
        public DbSet<UserLikeVideo> UserLikeVideos { get; set; }
        public DbSet<UserWatchVideo> UserWatchVideos { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // for identity default configs

            modelBuilder.ApplyConfiguration(new GameConfigs());

            //    modelBuilder.Entity<Comment>(entity =>
            //    {
            //        entity.HasKey(c => c.Id);

            //        entity.Property(c => c.Body)
            //              .IsRequired()
            //              .HasMaxLength(1000);

            //        entity.Property(c => c.CreatedAt)
            //              .HasDefaultValueSql("GETUTCDATE()");

            //        entity.HasOne(c => c.Owner)
            //              .WithMany(u => u.Comments)
            //              .HasForeignKey(c => c.OwnerId)
            //              .OnDelete(DeleteBehavior.Cascade);

            //        entity.HasOne(c => c.Video)
            //              .WithMany(v => v.Comments)
            //              .HasForeignKey(c => c.VideoId)
            //              .OnDelete(DeleteBehavior.Cascade);
            //    });

            //    modelBuilder.Entity<Country>(entity =>
            //    {
            //        entity.HasKey(c => c.Id);

            //        entity.Property(c => c.Name)
            //              .IsRequired()
            //              .HasMaxLength(100);

            //        entity.Property(c => c.Image)
            //              .HasMaxLength(500);

            //        entity.HasMany(c => c.GameStudios)
            //              .WithOne(gs => gs.Country)
            //              .HasForeignKey(gs => gs.CountryId)
            //              .OnDelete(DeleteBehavior.Cascade);
            //    });

            //    modelBuilder.Entity<GameImage>(entity =>
            //    {
            //        entity.HasKey(i => i.Id);

            //        entity.Property(i => i.Url)
            //              .IsRequired()
            //              .HasMaxLength(500);

            //        entity.HasOne(i => i.Game)
            //              .WithMany(g => g.Images)
            //              .HasForeignKey(i => i.GameId)
            //              .OnDelete(DeleteBehavior.Cascade);
            //    });
        }
    }
}
