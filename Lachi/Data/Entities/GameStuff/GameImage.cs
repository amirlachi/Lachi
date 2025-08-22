namespace Lachi.Data.Entities.GameStuff
{
    public class GameImage : BaseEntity
    {
        public string Path { get; set; } = null!;
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
    }
}
