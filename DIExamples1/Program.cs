using ServiceContracts;
using Services1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Add(new ServiceDescriptor(
    typeof(ICitiesContracts), typeof(CitiesServices), ServiceLifetime.Transient
    ));
var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
