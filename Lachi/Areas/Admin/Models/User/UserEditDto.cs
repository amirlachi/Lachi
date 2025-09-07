using System.ComponentModel.DataAnnotations;

namespace Lachi.Areas.Admin.Models.User
{
    public class UserEditDto
    {
        [Display(Name = "نام")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]
        [MaxLength(150, ErrorMessage = "حداکثر تعداد کاراکتر مجاز برای نام کاربری 150 کاراکتر میباشد")]
        public required string UserName { get; set; }
    }
}
