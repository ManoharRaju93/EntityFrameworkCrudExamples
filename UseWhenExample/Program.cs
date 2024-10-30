var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    context => context.Request.Query.ContainsKey("userName"),
     app =>
     {
         app.Use(async (context, next) =>
         {
             await context.Response.WriteAsync("hello from mw branch\n");
         await next();
             });
        });

app.Run(async context => {
    await context.Response.WriteAsync("\n hello from main branch doesn't contains username\n");
});

app.Run();
