using PetShopClientServise.Extensions;
using PetShopClientServise.Servises.AnimalServise;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAnimalApiServise, AnimalApiServise>();
builder.Services.AddApiServises();

var app = builder.Build();
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();