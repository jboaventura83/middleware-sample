﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareExample.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HelloCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //before logic
            if (httpContext.Request.Query.ContainsKey("firstname") && httpContext.Request.Query.ContainsKey("lastname"))
            {
                string fullname = "Middleware 2, fullname -- > " + httpContext.Request.Query["firstname"] + " " + httpContext.Request.Query["lastname"] + "\n";
                await httpContext.Response.WriteAsync(fullname);
            }
            
            // next call
            await _next(httpContext);

            //after logic
            if (httpContext.Request.Query.ContainsKey("nickname"))
            {
                string nick = "Middleware 2, nickname --> " + httpContext.Request.Query["nickname"] + ", returned in after logic \n";
                await httpContext.Response.WriteAsync(nick);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HelloCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloCustomMiddleware>();
        }
    }
}
