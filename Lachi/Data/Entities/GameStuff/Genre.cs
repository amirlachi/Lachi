namespace Lachi.Data.Entities.GameStuff
{
    public class Genre: BaseEntity
    {
        public string Title { get; set; } = null!;
        public ICollection<Game>? Games { get; set; }
    }
}
