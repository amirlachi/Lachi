namespace Lachi.Models.Common
{
    public class FilterRequest
    {
        public string FieldName { get; set; } = null!;
        public FilterRequestOperatorType OperatorType { get; set; }
        public string Value { get; set; } = null!;
    }
}
