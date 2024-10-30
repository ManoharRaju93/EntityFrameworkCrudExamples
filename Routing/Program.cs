var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddRouting(options =>
//{
//    options.ConstraintMap.Add("month", typeof(monthscustomcontraint));
//});
var app = builder.Build();

//app use GetEndpoint at begining

//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//    if (endPoint != null)
//    {
//        await context.Response.WriteAsync($" the endpoint is {endPoint.DisplayName}\n");
//    }
//    await next(context);
//});

// app routing initalize
app.UseRouting();

// Routing 

app.UseEndpoints(endpoints =>
{
    if (endpoints != null)
    {
        // File Details URL
        endpoints.Map("files/{filename}.{extensions}", async context =>
        {
            string? routeParameter = Convert.ToString(context.Request.RouteValues["filename"]);
            string? routeExtension = Convert.ToString(context.Request.RouteValues["extensions"]);

            await context.Response.WriteAsync($"inside the file {routeParameter}-{routeExtension}");
        });

        //Employees details URL
        endpoints.Map("employee/profile/{employeename:length(3,4)=MH}", async context =>
        {
            string? employeeName = Convert.ToString(context.Request.RouteValues["EmployeeName"]);
            await context.Response.WriteAsync($"inside the Employee URL {employeeName}");
        });

        //Products details URL

        endpoints.Map("products/Details/{id:int?}", async context =>
        {
            if (context.Request.RouteValues.ContainsKey("id"))
            {
                int id = Convert.ToInt32(context.Request.RouteValues["id"]);
                await context.Response.WriteAsync($"Products details is - {id}\n");

            }
            else
            {
                await context.Response.WriteAsync($"Products details is not found \n");

            }
        });
    }
  });

//app use GetEndpoint at ending
//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//    if (endPoint != null)
//    {
//        await context.Response.WriteAsync($" the endpoint is {endPoint.DisplayName}\n");

//    }
//    await next(context);
//});

//app endpoints
//app.UseEndpoints(endpoints => 
//{
//    if (endpoints != null)
//    {
//        //adding the endpoints
//        endpoints.MapGet("map1", async (context) =>
//        {
//            await context.Response.WriteAsync("From Map1");
//        });

//        endpoints.MapPost("map2", async (context) =>
//        {
//            await context.Response.WriteAsync("From Map2");
//        });
//    }
//});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request  Recived at from RUN Executing last{context.Request.Path}");
});

app.Run();
