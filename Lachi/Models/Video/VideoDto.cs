namespace Lachi.Models.Video
{
    public class VideoDto
    {
        public Guid UserChannelId { get; set; }
        public string Title { get; set; } = "";
        public string ThumbnailPath { get; set; } = "";
    }
}
