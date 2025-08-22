using Lachi.Data.Entities.GameStuff;
using Lachi.Data.Entities.VideoStuff;

using Microsoft.AspNetCore.Identity;

namespace Lachi.Data.Entities.UserStuff
{
    public class User:IdentityUser<Guid>
    {
        public string? Bio { get; init; }
        public ICollection<Video>? FavoriteVideos { get; set; }
        public ICollection<Game>? FavoriteGames { get; set; }
        public ICollection<Video>? UploadedVideos { get; set; }
        public ICollection<UserFollow> Followers { get; set; } = new HashSet<UserFollow>();
        public ICollection<UserFollow> Followings { get; set; } = new HashSet<UserFollow>();
        public ICollection<VideoComment>? Comments { get; set; }
        public ICollection<UserLikeVideo>? LikedVideos { get; set; }
        public ICollection<UserWatchVideo>? WatchedVideos { get; set; }

    }
}
