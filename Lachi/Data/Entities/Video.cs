using Lachi.Data.Entities.GameStuff;
using Lachi.Data.Entities.UserStuff;

namespace Lachi.Data.Entities
{
    public class Video: BaseEntity
    {
        public string Path { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        public string Description { get; set; } = null!;
        public Guid OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<VideoStatus> Statuses { get; set; }
    }
}
