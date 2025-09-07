using System.ComponentModel.DataAnnotations;

namespace Lachi.Models.Video
{
    public class UploadVideoDto
    {
        [Required(ErrorMessage = "وارد کردن عنوان الزامی است")]
        [MaxLength(200, ErrorMessage = "حداکثر طول عنوان 200 کاراکتر است")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "وارد کردن توضیحات الزامی است")]
        [MaxLength(1000, ErrorMessage = "حداکثر طول توضیحات 1000 کاراکتر است")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "انتخاب بازی الزامی است")]
        public int GameId { get; set; }

        [Required(ErrorMessage = "انتخاب فایل ویدیو الزامی است")]
        public IFormFile File { get; set; } = null!;
    }
}
