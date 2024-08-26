using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineShop.Application.Exceptions;
using Serilog;
using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace OnlineShop.Api.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exceptionObj)
            {
                await HandleExceptionAsync(context, exceptionObj);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int code;
            var result = exception.Message;

            switch (exception)
            {
                case BadRequestException badRequestException:
                    code = (int)HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;

                case NotFoundException:
                    code = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    code = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            Log.Error(exception, result);

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new { StatusCode = code, ErrorMessage = exception.Message }));
        }
    }
}