using System.Net;

namespace Movie.API.Responses
{
    public class Respone
    {
        public bool Success {  get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
