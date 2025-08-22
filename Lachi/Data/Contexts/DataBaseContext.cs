using Lachi.Data.Users;
using Microsoft.EntityFrameworkCore;

namespace Lachi.Data.Contexts
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameStudio> GameStudios { get; set; }
        public DbSet<GameImage> GameImages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Game>(entity =>
        //    {
        //        entity.HasKey(g => g.Id);

        //        entity.Property(g => g.Title)
        //              .IsRequired()
        //              .HasMaxLength(200);

        //        entity.Property(g => g.Description)
        //              .HasMaxLength(2000);

        //        entity.Property(g => g.TrailerUrl)
        //              .HasMaxLength(500);

        //        entity.HasOne(g => g.GameStudio)
        //          .WithMany(s => s.Games)
        //          .HasForeignKey(g => g.GameStudioId)
        //          .OnDelete(DeleteBehavior.Cascade);

        //        entity.HasMany(g => g.Images)
        //              .WithOne(i => i.Game)
        //              .HasForeignKey(i => i.GameId);

        //        entity.HasMany(g => g.Genres)
        //              .WithMany(ge => ge.Games)
        //              .UsingEntity(j => j.ToTable("GameGenres"));
        //    });

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
        //}
    }
}
