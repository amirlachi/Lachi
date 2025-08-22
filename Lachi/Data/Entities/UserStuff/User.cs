using Lachi.Data.Entities.GameStuff;

using Microsoft.AspNetCore.Identity;

namespace Lachi.Data.Entities.UserStuff
{
    public class User:IdentityUser<Guid>
    {
        public string? Bio { get; init; }
        public ICollection<Video>? FavoriteVideos { get; set; }
        public ICollection<Game>? FavoriteGames { get; set; }
        public ICollection<UserFollow> Followers { get; set; } = new HashSet<UserFollow>();
        public ICollection<UserFollow> Followings { get; set; } = new HashSet<UserFollow>();
        public ICollection<Comment>? Comments { get; set; }

    }
}
