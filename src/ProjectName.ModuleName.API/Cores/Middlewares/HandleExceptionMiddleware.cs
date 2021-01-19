using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Stu.AspNetCore.Mvc.Implements;
using Stu.AspNetCore.Mvc.Interfaces;

namespace Stu.AspNetCore.Mvc.Middlewares
{
    public static class HandleExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseHandleExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandleExceptionMiddleware>();
        }
    }

    public class HandleExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HandleExceptionMiddleware> _logger;

        public HandleExceptionMiddleware(RequestDelegate next, ILogger<HandleExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (IsDefault(context))
                {
                    await _next(context);
                }
                else
                {
                    try
                    {
                        await _next.Invoke(context);
                    }
                    catch (System.Exception ex)
                    {
                        if (ex! is ValidateException)
                        {
                            _logger.LogError(ex, ex.Message);
                        }
                        await HandleExceptionAsync(context, ex);
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string apiMessage = exception.GetBaseException().Message;
            IErrorCode errorCode = new SuccessCode();
            if (exception is UnhandledException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.WriteAsync(apiMessage);
            }
            else if (exception is ForbiddenException)
            {
                errorCode = new ForbiddenCode();
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else if (exception is UnauthorizedAccessException)
            {
                errorCode = new UnauthorizedCode();
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (exception is ValidateException)
            {
                errorCode = new InputInvalidCode();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            string json = JsonSerializer.Serialize(new ResultData<object>
            {
                Error = errorCode,
                Data = null
            });

            return context.Response.WriteAsync(json);
        }

        private bool IsDefault(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/");
        }
    }
}
