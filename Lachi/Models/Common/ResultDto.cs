namespace Lachi.Models.Common
{
    public class ResultDto(bool isSuccess, string? message = null)
    {
        public string? Message { get; set; } = message;
        public bool IsSuccess { get; set; } = isSuccess;
    }
    public class ResultDto<T>: ResultDto
    {
        public ResultDto(bool isSuccess, string? message = null) : base(isSuccess, message)
        {
        }

        public T? Data { get; set; }
    }
}
