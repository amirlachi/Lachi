using Lachi.Models.Video;

namespace Lachi.Models.Channel
{
    public class UserChannelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }

        public List<VideoDto> Videos { get; set; } = new List<VideoDto>();
        public List<PlaylistDto> Playlists { get; set; } = new List<PlaylistDto>();
    }
}
