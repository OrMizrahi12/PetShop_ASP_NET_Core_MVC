using Microsoft.AspNetCore.Diagnostics;
using PetShopClient.ViewComponents;
using PetShopClientServise.Extensions;
using PetShopClientServise.Servises.AnimalServise;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAnimalApiService, AnimalApiService>();
builder.Services.AddApiServises();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();



app.UseStatusCodePagesWithReExecute("/Error/Index/{0}");


app.UseStaticFiles();
app.UseSession();
app.UseRouting();


app.MapDefaultControllerRoute();
app.Run();