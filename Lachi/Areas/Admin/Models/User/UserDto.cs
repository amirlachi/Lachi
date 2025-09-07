
namespace Lachi.Areas.Admin.Models.User
{
    public class UserDto : BaseDto
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public required string UserName { get; set; }
        public List<string> Roles { get; set; } = new();
        public int UploadedVideoCounts { get; set; }
    }
}
