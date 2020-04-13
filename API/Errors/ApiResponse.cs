using System;

namespace API.Errors
{
    public class ApiResponse
    {
       

        public int StatusCode { get; set; }
        public string Message { get; set; }

        
         public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? getDefaultMessageForStatusCode(statusCode);
        }

        private string getDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you have not",
                404 => "Resource found, it was made",
                500 => "Errors are the path to the dark side.. Errors lead to anger",
                _ => null
            };
        }

    }
}