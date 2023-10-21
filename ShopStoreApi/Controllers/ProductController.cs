using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopStoreApi.Data.Context;
using ShopStoreApi.Entity.Products;

namespace ShopStoreApi.Controllers;

[ApiController]
[Route("asi/[controller]")]
public class ProductController : ControllerBase
{
    private readonly StoreContext _context;

    public ProductController(StoreContext context)
    {
        _context = context;
    }

//get product from database
    [HttpGet]
    public async Task<List<product>> GetAllProduct()
    {
        var products = await _context.prooduct.ToListAsync();

        return products;
    }

// this command  get on product in our application 
    [HttpGet("{id}")]
    public async Task<product> Getproduct(int id)
    {
        try
        {
            var product = await _context.prooduct.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}