using System.Net;
using System.Text.Json;

namespace SchoolApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext iContext)
        {
            try
            {
                await _next(iContext);
            }
            catch (Exception e)
            {
                await _HandleExceptionAsync(iContext, e);
            }
        }

        private Task _HandleExceptionAsync(HttpContext iContext, Exception iException)
        {
            iContext.Response.ContentType = "application/json";
            iContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = JsonSerializer.Serialize(new
            {
                status = iContext.Response.StatusCode,
                error = iException.Message
            });

            return iContext.Response.WriteAsync(json);
        }
    }
}
