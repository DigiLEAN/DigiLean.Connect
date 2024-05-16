using System.Net;

namespace DigiLean.Api.Model.Clients
{
    public class DigiLeanApiException : ApplicationException
    {
        public HttpStatusCode StatusCode { get; set; }

        public DigiLeanApiException()
        {
        }

        public DigiLeanApiException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public DigiLeanApiException(string message, Exception inner, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(message, inner)
        {
            StatusCode = statusCode;
        }
    }
}
