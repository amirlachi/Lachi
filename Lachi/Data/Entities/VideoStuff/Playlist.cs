using Lachi.Data.Entities.UserStuff;

namespace Lachi.Data.Entities.VideoStuff
{
    public class Playlist : BaseEntity
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public int UserChannelId { get; set; }
        public UserChannel UserChannel { get; set; } = null!;

        public ICollection<Video> Videos { get; set; } = new List<Video>();
    }
}
