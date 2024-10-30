
using System.Runtime.CompilerServices;

namespace MiddlewareExample.CustomMiddleWare
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("From Custom Middle ware Starts here from middleware 2 \n");
            await next(context);
            await context.Response.WriteAsync("From Custom Middle ware Ends here  middleware 2 \n");
        }
    }

    public static class CustomMiddleWareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}

