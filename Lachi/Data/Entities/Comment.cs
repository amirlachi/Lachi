using Lachi.Data.Entities.UserStuff;

namespace Lachi.Data.Entities
{
    public class Comment : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        public int VideoId { get; set; }
        public Video Video { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
