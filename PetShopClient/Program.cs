using PetShopClientServise.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
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