namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // before logic
            await context.Response.WriteAsync("My Custom Middleware - Starts\n");
            await next(context);
            // after logic
            await context.Response.WriteAsync("My Custom Middleware - Ends\n");
        }               
    }


    // Creating an extension
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
