namespace Lachi.Data.Users
{
    public class Video
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        public string Description { get; set; }
        public User Owner { get; set; }
        public Game Game { get; set; }
        public List<string> Comments { get; set; }
    }
}
