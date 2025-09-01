using System.ComponentModel.DataAnnotations;

namespace Lachi.Areas.Admin.Models.User
{
    public class UserCreateDto
    {
        [Display(Name = "نام")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage ="وارد کردن نام کاربری الزامی است")]
        [MaxLength(150, ErrorMessage = "حداکثر تعداد کاراکتر مجاز برای نام کاربری 150 کاراکتر میباشد")]
        public required string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name ="تکرار رمز عبور")]
        [Required(ErrorMessage ="تکرار رمز عبور را وارد کنید")]
        [Compare(nameof(Password), ErrorMessage ="رمز عبور و تکرارش یکسان نیست")]
        [DataType(DataType.Password)]
        public required string RePassword { get; set; }
    }
}
