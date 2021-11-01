using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, 
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        // has to be called InvokeAsync
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // stays at top of tree and catches any exceptions that haven't yet been handled further down the middleware tree
                // see here: [insert MSFT.com link]
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                // format returned from API to our client
                context.Response.ContentType = "application/json";
                // internal server error to indicate from server side
                context.Response.StatusCode = 500;

                var response = new ProblemDetails
                {
                    Status = 500,
                    // convert to string so we don't get null reference exception
                    Detail = _env.IsDevelopment() ? e.StackTrace?.ToString() : null,
                    Title = e.Message
                };

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy =
                        JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}