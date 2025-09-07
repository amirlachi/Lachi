namespace Lachi.Models.Channel
{
    public class UserChannelCreateDto
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public string? UserId { get; set; }
    }
}
