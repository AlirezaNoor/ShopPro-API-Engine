
using Microsoft.EntityFrameworkCore;


namespace ShopStoreApi.Data.Context;

public class StoreContext:DbContext
{
    public StoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<product> prooduct { get; set; }
}