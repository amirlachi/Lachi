namespace Lachi.Data.Entities.VideoStuff
{
    public enum VideoStatusType
    {
        _,
        Reject,
        Accept
    }
    public class VideoStatus: BaseEntity
    {
        public VideoStatusType Status { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; } = null!;
    }
}
