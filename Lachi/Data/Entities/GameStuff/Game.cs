namespace Lachi.Data.Entities.GameStuff
{
    public class Game : BaseEntity
    {
        public string Title { get; set; } = null!;
        public int GameStudioId { get; set; }
        public GameStudio GameStudio { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public string TrailerVideoPath { get; set; } = null!;
        public ICollection<GameImage> Images { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Genre> Genres { get; set; } = null!;
    }
}
