namespace Lachi.Data.Users
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public User Owner { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
