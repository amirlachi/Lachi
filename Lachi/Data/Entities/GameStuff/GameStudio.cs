namespace Lachi.Data.Entities.GameStuff
{
    public class GameStudio: BaseEntity
    {
        public string Title { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime FoundedYear { get; set;}
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
    }
}
