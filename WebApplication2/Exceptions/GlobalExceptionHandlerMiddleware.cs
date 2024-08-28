using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace WebApplication2.Exceptions
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var exceptionObject = new ExceptionObjects();
            var exceptionDetails = exceptionObject.GetExceptionDetails(ex);

            _logger.Log(exceptionDetails.LogLevel, ex, exceptionDetails.LogMessage);
            context.Response.StatusCode = exceptionDetails.StatusCode;
            await context.Response.WriteAsJsonAsync(new { error = exceptionDetails.ErrorTitle, message = exceptionDetails.Message });
        }

       
    }



}
