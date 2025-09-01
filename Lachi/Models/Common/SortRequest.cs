namespace Lachi.Models.Common
{
    public class SortRequest
    {
        public required string Field { get; set; }
        public bool IsASC { get; set; } = true;
    }
}
