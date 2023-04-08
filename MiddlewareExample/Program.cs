using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    // before logic
    await context.Response.WriteAsync("Response from Middleware 1!\n");
    // call next
    await next(context);
    // after logic
    await context.Response.WriteAsync("Response from Middleware 1, after logic!\n");
});

// Call Custom Middleware
//app.UseMyCustomMiddleware();

// Call Custom Hello Middleware
app.UseHelloCustomMiddleware();

// middleware 3
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    // before logic
    await context.Response.WriteAsync("It's is a response from Middleware 3!\n");
    // call next
    await next(context);
    // after logic
    await context.Response.WriteAsync("It's is a response from Middleware 3!, after logic\n");
});

app.Run();
