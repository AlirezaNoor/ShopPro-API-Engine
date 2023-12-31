 using Core.Interface.UnitofWork;
 using Infrastructure;
using Infrastructure.Data.Repository;
using Infrastructure.Data.Repository.GenericRepository;
 using Infrastructure.UnitofWork;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;
using ShopStoreApi.Data.Context;
 using ShopStoreApi.Errors;
 using ShopStoreApi.Middleware;

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

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
 
#endregion

 builder.Services.Configure<ApiBehaviorOptions>(opt =>
 {
  opt.InvalidModelStateResponseFactory = actionContext =>
  {
   var error = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
    .SelectMany(x => x.Value.Errors)
    .Select(x => x.ErrorMessage);
   var errorresponse = new ApivalidationErrorResponse()
   {
    Errors = error
   };
   return new BadRequestObjectResult(errorresponse);
  };
 });

var app = builder.Build();
 app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");
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