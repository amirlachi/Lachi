using Lachi.Data.Entities.UserStuff;
using Lachi.Data.Entities.VideoStuff;

namespace Lachi.Data.Entities
{
    public class UserLikeVideo
    {
        public int VideoId { get; set; }
        public Video Video { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
