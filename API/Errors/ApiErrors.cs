namespace API.Errors
{
    public class ApiErrors : ApiResponse
    {
        public string Details { get; set; }
        public ApiErrors(int statusCode, string message = null, string details =null) : base(statusCode, message)
        {
            Details=details;
        }
    }
}