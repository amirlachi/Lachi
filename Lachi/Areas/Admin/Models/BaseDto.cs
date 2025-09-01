namespace Lachi.Areas.Admin.Models
{
    public abstract class BaseDto
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public required CreateByDto CreatedBy { get; set; }
        public UpdateByDto? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateByDto
    {
        public required string UserName { get; set; }
        public string? FullName { get; set; }
    }
    public class UpdateByDto
    {
        public required string UserName { get; set; }
        public string? FullName { get; set; }
    }
}
