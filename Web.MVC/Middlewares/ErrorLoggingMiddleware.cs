using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.MVC.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly ILogger Log = Serilog.Log.ForContext<ErrorLoggingMiddleware>();
        private string messageTemplate = "HTTP {RequestMethod} {RequestPath} Status code: {StatusCode}";

        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                Log.Information($"Before request: {context.Request.Path}");
                await _next(context);
            }
            catch (Exception ex)
            {
                var request = context.Request;

                var result = Log.ForContext("RequestHeader", request.Headers.ToDictionary(k => k.Key, h => h.Value.ToString()), destructureObjects: true)
                    .ForContext("RequestHost", request.Host)
                    .ForContext("RequestProtocol", request.Protocol);

                if (request.HasFormContentType)
                    result = result.ForContext("RequestForm", request.Form.ToDictionary(k => k.Key, h => h.Value.ToString()));

                result.Error(ex, messageTemplate, context.Request.Method, context.Request.Path, 500);

                throw;
            }
        }
    }
}
