using Lachi.Data.Entities.GameStuff;
using Lachi.Data.Entities.UserStuff;

namespace Lachi.Data.Entities.VideoStuff
{
    public class Video: BaseEntity
    {
        public string Path { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int ViewCount { get; set; }
        public string Description { get; set; } = null!;
        public Guid OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
        public int UserChannelId { get; set; }
        public UserChannel UserChannel { get; set; } = null!;
        public ICollection<Playlist>? Playlists { get; set; }
        public ICollection<VideoComment>? Comments { get; set; }
        public ICollection<VideoStatus> Statuses { get; set; } = new HashSet<VideoStatus>();
        public ICollection<User>? FavoriteByUsers { get; set; }
        public ICollection<UserLikeVideo>? UserLikes { get; set; }
        public ICollection<UserWatchVideo>? UserWatches { get; set; }
    }
}
