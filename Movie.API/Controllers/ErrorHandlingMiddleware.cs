using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Movie.API.Controllers
{
    public class ErrorHandlingMiddleware {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch
            {
                context.Response.StatusCode = 500; // Internal Server Error
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { status = "false" ,message = "hihi!!" }));
            }

        }
    }
}
