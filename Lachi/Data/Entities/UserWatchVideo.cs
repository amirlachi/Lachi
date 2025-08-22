using Lachi.Data.Entities.UserStuff;
using Lachi.Data.Entities.VideoStuff;

namespace Lachi.Data.Entities
{
    public class UserWatchVideo
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public int VideoId { get; set; }
        public Video Video { get; set; } = null!;
        public int LastWatchAtMinute { get; set; }
        public DateTime LastDateWatchAt { get; set; } = DateTime.Now;
    }
}
