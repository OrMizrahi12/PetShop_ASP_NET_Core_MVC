using PetShopClientServise.Extensions;
using PetShopClientServise.Servises.AnimalServise;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAnimalApiService, AnimalApiService>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddApiServises();

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.UseStatusCodePagesWithReExecute("/Error/Index/{0}");

app.UseStaticFiles();
app.UseRouting();


app.MapDefaultControllerRoute();
app.Run();