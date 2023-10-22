using Core.Interface.IReposetory;
using Infrastructure;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using ShopStoreApi.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

#region DependencyInjection

builder.Services.AddScoped<IproductRepository, productRepository>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;
var context = service.GetRequiredService<StoreContext>();
var Loger = service.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await SeedStoreContext.SeedAsync(context);
}
catch (Exception e)
{
    Console.WriteLine(e);
 Loger.LogError(e,"this is not worke ");
}
app.Run();