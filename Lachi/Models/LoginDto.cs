using System.ComponentModel.DataAnnotations;

namespace Lachi.Models
{
    public class LoginDto
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]
        [MaxLength(150, ErrorMessage = "حداکثر تعداد کاراکتر مجاز برای نام کاربری 150 کاراکتر میباشد")]
        public string UserName { get; set; } = "";

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        public string Password { get; set; } = "";

        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
