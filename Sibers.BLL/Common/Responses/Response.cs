using System.Text.Json;

namespace Sibers.BLL.Common.Responses
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public Response(int statusCode, string message, bool isSuccess)
        {
            StatusCode = statusCode;
            Message = message;
            IsSuccess = isSuccess;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
