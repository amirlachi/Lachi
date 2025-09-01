namespace Lachi.Areas.Admin.Models.Country
{
    public class CountryDto:BaseDto
    {
        public required string Name { get; set; }
        public string? FlagPath { get; set; }
    }
}
