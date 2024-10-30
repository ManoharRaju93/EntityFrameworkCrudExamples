using ConfigurationSamples;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<WeatherApi>
    (builder.Configuration.GetSection("weatherapi"));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/config", async context =>
//    {
//        await context.Response.WriteAsync
//        (app.Configuration["MyKey"]+"\n");

//        await context.Response.WriteAsync
//        (app.Configuration.GetValue<int>("x", 0)+"\n");
//    });
//});
app.MapControllers();

app.Run();
