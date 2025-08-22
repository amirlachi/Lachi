using Lachi.Data.Entities.GameStuff;

namespace Lachi.Data.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? FlagPath { get; set; }
        public ICollection<GameStudio>? GameStudios { get; set; }
    }
}
