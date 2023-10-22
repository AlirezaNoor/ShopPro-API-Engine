using System.Text.Json;
using ShopStoreApi.Data.Context;

namespace Infrastructure;

public class SeedStoreContext
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.prooducttype.Any())
        {
            var producttypefile = File.ReadAllText("../Infrastructure/SeedData/productTypes.json");
            var producttypedata = JsonSerializer.Deserialize<List<ProductType>>(producttypefile);
            context.prooducttype.AddRange(producttypedata);
        }
        if (!context.prooductbrand.Any())
        {
            var productbrandfile = File.ReadAllText("../Infrastructure/SeedData/Productbrans.json");
            var productbranddata = JsonSerializer.Deserialize<List<ProductBrand>>(productbrandfile);
            context.prooductbrand.AddRange(productbranddata);
        }
        if (!context.prooduct.Any())
        {
            var productfile = File.ReadAllText("../Infrastructure/SeedData/Product.json");
            var productdata = JsonSerializer.Deserialize<List<product>>(productfile);
            context.prooduct.AddRange(productdata);
        }

        if (context.ChangeTracker.HasChanges()) 
        {
            await context.SaveChangesAsync(); 
        }
    }
    
}