using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


using PetShopApiServise.Data;
using PetShopApiServise.Extensions;
using PetShopApiServise.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<PetShopDBContext> (o => o.UseSqlServer(builder.Configuration.GetConnectionString("PetShopDbConnectionString")));


builder.Services.AddDbContext<AuthenticationContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationConnectionString")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthenticationContext>();

builder.Services.AddRepositories();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
    //ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
