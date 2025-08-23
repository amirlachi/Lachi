using Lachi.Data.Entities.GameStuff;
using Lachi.Data.Entities.VideoStuff;

using Microsoft.AspNetCore.Identity;

namespace Lachi.Data.Entities.UserStuff
{
    public class User:IdentityUser<Guid>, IBaseEntity
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
        public ICollection<VideoComment> VideoComments { get; set; } = new List<VideoComment>();

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;
        public Guid? UpdatedById { get; set; }
        public User? UpdatedBy { get; set; }
        public Guid? RemovedById { get; set; }
        public User? RemovedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsRemoved { get; set; } = false;
    }
}
