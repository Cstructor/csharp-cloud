namespace HelloWorldService.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string Field { get; set; }
        public int DBCode { get; set; }
        public object Data { get; set; }
    }
}
