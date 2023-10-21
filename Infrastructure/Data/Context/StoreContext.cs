
using System.Reflection;
using Microsoft.EntityFrameworkCore;


namespace ShopStoreApi.Data.Context;

public class StoreContext:DbContext
{
    public StoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<product> prooduct { get; set; }
    public DbSet<ProductBrand> prooductbrand { get; set; }
    public DbSet<ProductType> prooducttype { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}