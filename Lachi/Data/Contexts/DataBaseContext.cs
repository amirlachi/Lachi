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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);

            _UserSeeding(modelBuilder);
        }



        private void _UserSeeding(ModelBuilder builder)
        {
            var roleId = "4a3b544c-b8dc-440f-9f74-a93d9a105ab7";
            var adminId = "fb129ef4-22b7-4fe4-b669-c95972bf5025";
            
            //seedRole
            builder.Entity<Role>().HasData(new Role
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = Guid.Parse(roleId),
                ConcurrencyStamp = roleId,
                CreatedById = Guid.Parse(adminId),
            });

            //createAdmin
            var admin = new User
            {
                Id = Guid.Parse(adminId),
                UserName = "ar.lachi@lachi.com",
                NormalizedUserName = "AR.LACHI@LACHI.COM",
                Email = "ar.lachi@lachi.com",
                NormalizedEmail = "ar.lachi@lachi.com",
                EmailConfirmed = true,
                FirstName = "امیر رضا",
                LastName = "لچینانی",
                CreatedById = Guid.Parse(adminId),
            };

            //setAdminPassword
            var passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "ArLachi123@");

            //seedAdmin
            builder.Entity<User>().HasData(admin);

            //seedIdentityUserRole
            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse(adminId),
                RoleId = Guid.Parse(roleId),
            });
        }
    }
}
