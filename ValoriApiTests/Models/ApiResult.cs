using System.Net;

namespace ValoriApiTests.Models
{
    internal class ApiResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public string? Body { get; set; }
    }
}
