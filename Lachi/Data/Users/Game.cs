namespace Lachi.Data.Users
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }
        public GameStudio GameStudio { get; set; }
        public DateTime PublishDate { get; set; }
        public string TrailerUrl { get; set; }
        public List<GameImage> Images { get; set; }
        public string Description { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
