using Lachi.Data.Contexts.Configs;
using Lachi.Data.Contexts.Configs.GameStuff;
using Lachi.Data.Contexts.Configs.UserStuff;
using Lachi.Data.Contexts.Configs.VideoStuff;
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

            modelBuilder.ApplyConfiguration(new CountryConfigs());

            modelBuilder.ApplyConfiguration(new GameConfigs());

            modelBuilder.ApplyConfiguration(new GameImageConfigs());

            modelBuilder.ApplyConfiguration(new GameStudioConfigs());

            modelBuilder.ApplyConfiguration(new GenreConfigs());

            modelBuilder.ApplyConfiguration(new UserConfigs());

            modelBuilder.ApplyConfiguration(new RoleConfigs());

            modelBuilder.ApplyConfiguration(new UserFollowConfigs());
            
            modelBuilder.ApplyConfiguration(new VideoCommentConfigs());

            modelBuilder.ApplyConfiguration(new VideoConfigs());

            modelBuilder.ApplyConfiguration(new VideoStatusConfigs());

            modelBuilder.ApplyConfiguration(new UserLikeVideoConfigs());

            modelBuilder.ApplyConfiguration(new UserWatchVideoConfigs());
        }
    }
}
