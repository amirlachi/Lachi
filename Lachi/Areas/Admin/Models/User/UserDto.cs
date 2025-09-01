
namespace Lachi.Areas.Admin.Models.User
{
    public class UserDto : BaseDto
    {
        public string? FullName { get; set; }
        public required string UserName { get; set; }
        public int UploadedVideoCounts { get; set; }
    }
}
