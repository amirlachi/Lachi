namespace Lachi.Models.Channel
{
    public class UserChannelEditDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
    }
}
