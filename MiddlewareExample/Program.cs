using MiddlewareExample.CustomMiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello calling from middleware 1 \n");
    await next(context);

});

//Custom Middleware calling
//app.UseMiddleware<MyCustomMiddleware>();

//Calling Middleware using Extension
//app.UseMyCustomMiddleware();

//Calling from CustomMiddlewareExtension template
app.UseHelloCustomMiddleware();

//Middleware 2
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Manohar");
//    await next(context);

//});

//Middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("\n Ending the middleware 3 \n");

});

app.Run();
