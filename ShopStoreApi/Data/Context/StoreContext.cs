using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopStoreApi.Entity.Products;

namespace ShopStoreApi.Data.Context;

public class StoreContext:DbContext
{
    public StoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<product> prooduct { get; set; }
}