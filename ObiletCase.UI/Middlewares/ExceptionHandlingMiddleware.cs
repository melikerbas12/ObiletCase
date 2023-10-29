using Newtonsoft.Json;
using ObiletCase.Core.Models;

namespace ObiletCase.UI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string routeWhereExceptionOccurred = context.Request.Path;
                var path = JsonConvert.SerializeObject(routeWhereExceptionOccurred);
                var result = new ErrorViewModel()
                {
                    StatusCode =  context.Response.StatusCode.ToString(),
                    Path = path,
                };

                if (ex is AggregateException ae)
                {
                    var messages = ae.InnerExceptions.Select(e => e.Message).ToList();
                    result.ErrorMessages = messages;
                    string messageJson = JsonConvert.SerializeObject(result);
                    context.Items["ErrorMessagesJson"] = messageJson;
                }
                else
                {
                    string message = ex.Message;
                    result.ErrorMessages = new List<string> { message };
                    string messageJson = JsonConvert.SerializeObject(result);
                    context.Items["ErrorMessagesJson"] = messageJson;
                }
                 HandleError(context);
            }
        }
        private static void HandleError(HttpContext context)
        {
            string? messagesJson = context.Items["ErrorMessagesJson"] as string;
            string redirectUrl = $"/Home/Error?messagesJson={messagesJson}";
            context.Response.Redirect(redirectUrl);
        }
    }
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
