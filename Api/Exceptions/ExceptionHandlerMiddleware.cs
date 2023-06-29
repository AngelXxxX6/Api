using Newtonsoft.Json;
using System.Net;

namespace Api.Exceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex, HttpStatusCode.InternalServerError)
                    .ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionMessageAsync(
            HttpContext context,
            Exception exception,
            HttpStatusCode httpStatusCode
        )
        {
            context.Response.ContentType = "application/json";
            int statusCode = (int)httpStatusCode;
            var result = JsonConvert.SerializeObject(
                new { StatusCode = statusCode, ErrorMessage = exception.Message }
            );

            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
