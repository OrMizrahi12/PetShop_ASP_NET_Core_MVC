using PetShopClient.ViewComponents;
using PetShopClientServise.Extensions;
using PetShopClientServise.Servises.AnimalServise;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAnimalApiServise, AnimalApiServise>();
builder.Services.AddApiServises();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();