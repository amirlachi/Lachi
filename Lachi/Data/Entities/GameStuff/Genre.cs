namespace Lachi.Data.Entities.GameStuff
{
    public class Genre
    {
        public string Title { get; set; } = null!;
        public ICollection<Game>? Games { get; set; }
    }
}
