namespace Lachi.Data.Entities.GameStuff
{
    public class Country : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? FlagPath { get; set; }
        public ICollection<GameStudio>? GameStudios { get; set; }
    }
}
