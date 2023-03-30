using Microsoft.EntityFrameworkCore;
using PetShopApiServise.Extensions;
using PetShopApiServise.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PetShopDBContext>
    (o => o.UseSqlServer(builder.Configuration.GetConnectionString("PetShopDbConnectionString")));
builder.Services.AddRepositories();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
