namespace CustomerManagerWebApi.Extensions
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string Error { get; set; }
        public object Details { get; set; }
    }
}
