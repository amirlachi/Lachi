namespace Lachi.Data.Users
{
    public class GameImage : BaseEntity
    {
        public string Url { get; set; }
        public int GameId { get; set; }
        public Game Game {  get; set; }
    }
}
