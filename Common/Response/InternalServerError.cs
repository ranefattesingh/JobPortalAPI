using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Common.Response
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class InternalServerError : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;
        public InternalServerError() : base("server failed to handle the request.")
        {
            StatusCode = DefaultStatusCode;
        }
    }
}