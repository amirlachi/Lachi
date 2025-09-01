using System.ComponentModel.DataAnnotations;

namespace Lachi.Areas.Admin.Models.Country
{
    public class CountryDropDownDto
    {
        public required string Name { get; set; }
        public string? FlagPath { get; set; }
    }

    public class CountryCreateDto
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام را وارد کنید")]
        [MaxLength(100, ErrorMessage = "نام کشور نمیتواند بیش از 100 کاراکتر باشد")]
        public required string Name { get; set; }

        [Display(Name = "پرچم")]
        public IFormFile? Flag { get; set; }
    }
}
