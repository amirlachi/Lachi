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

using System;
using System.Security.Claims;

namespace Lachi.Data.Contexts
{
    public class DataBaseContext : IdentityDbContext<User, Role, Guid>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public DataBaseContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
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
        public DbSet<UserChannel> UserChannels { get; set; }
        #endregion

        #region VideoStuff
        public DbSet<Playlist> Playlists { get; set; }
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
            {
                if (entry.State == EntityState.Added && userId is not null)
                {
                    entry.Entity.CreatedById = Guid.Parse(userId);
                }
                else if (entry.State == EntityState.Modified && userId is not null)
                {
                    entry.Entity.UpdateAt = DateTime.Now;
                    entry.Entity.UpdatedById = Guid.Parse(userId);
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
