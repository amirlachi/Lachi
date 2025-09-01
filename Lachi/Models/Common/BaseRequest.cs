namespace Lachi.Models.Common
{
    public class BaseRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public List<FilterRequest>? Filters { get; set; }
        public List<SortRequest>? Sorts { get; set; }
    }
}
