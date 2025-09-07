using Lachi.Data.Entities.VideoStuff;
using Microsoft.AspNetCore.Identity;

namespace Lachi.Data.Entities.UserStuff
{
    public class UserChannel : BaseEntity
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; } = "";
        public string? ProfileImagePath { get; set; }
        public string? BannerImagePath { get; set; }

        public ICollection<Video> Videos { get; set; } = new List<Video>();
        public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
