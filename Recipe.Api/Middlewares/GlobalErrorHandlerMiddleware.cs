using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Recipe.Api.Middlewares
{
    public class GlobalErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalErrorHandlerMiddleware> _logger;

        public GlobalErrorHandlerMiddleware(ILogger<GlobalErrorHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                ValidationExceptionHandler(context, ex);
            }
            catch (Exception ex)
            {
                ExceptionHandler(context, ex);
            }
        }


        //Error Validation Methods
        private async void ValidationExceptionHandler(HttpContext context, ValidationException ex)
        {
            _logger.LogError($"Validation error at {ex.Source} : {ex.Message} \n Details : {ex.ValidationResult}");

            ProblemDetails problem = new()
            {
                Title = ex.Message,
                Status = (int)HttpStatusCode.BadRequest,
                Type = "Validation Error",
                Detail = ex.ValidationResult.ToString()
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var body = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(body);
        }

        private async void ExceptionHandler(HttpContext context, Exception ex)
        {
            _logger.LogError($"Server error at {ex.Source} : {ex.Message} \n Details : {ex.Message}");

            ProblemDetails problem = new()
            {
                Title = ex.Message,
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Internal Server Error",
                Detail = ex.Message.ToString()
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var body = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(body);
        }
    }
}
