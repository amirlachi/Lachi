using System.ComponentModel.DataAnnotations;

namespace Lachi.Models
{
    public class ProfileDto
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        [MaxLength(50, ErrorMessage = "حداکثر تعداد کاراکتر مجاز برای نام 50 کاراکتر می‌باشد")]
        public string FirstName { get; set; } = "";

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است")]
        [MaxLength(50, ErrorMessage = "حداکثر تعداد کاراکتر مجاز برای نام خانوادگی 50 کاراکتر می‌باشد")]
        public string LastName { get; set; } = "";

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]
        [MaxLength(150, ErrorMessage = "حداکثر تعداد کاراکتر مجاز برای نام کاربری 150 کاراکتر می‌باشد")]
        public string UserName { get; set; } = "";

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی‌باشد")]
        [MaxLength(200, ErrorMessage = "حداکثر تعداد کاراکتر مجاز برای ایمیل 200 کاراکتر می‌باشد")]
        public string Email { get; set; } = "";
    }
}
