﻿using MongoDB.Bson.IO;
using System.Net;
using System.Text.Json.Serialization;

namespace E_Commerce
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
             
                _logger.LogError(ex, "An unhandled exception occurred.");

             
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            // Create a response object
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred.",
                Detailed = exception.Message 
            };


            var jsonResponse = response.Message;  
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}

