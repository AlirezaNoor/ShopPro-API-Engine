 using System.Text.Json;
 using Core.Interface.IReposetory;
 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopStoreApi.Data.Context;


namespace ShopStoreApi.Controllers;

[ApiController]
[Route("asi/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IproductRepository _rep;

    public ProductController(IproductRepository rep)
    {
        _rep = rep;
    }

    //get product from database
    [HttpGet]
    public async Task<IReadOnlyList<product>> GetAllProduct()
    {
        var products = await _rep.GetProductsAsync();

        return products;
    }

// this command  get on product in our application 
    [HttpGet("{id}")]
    public async Task<product> Getproduct(int id)
    {
        try
        {
 
            var product = await _rep.GetBtIdAsync(id);
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
[HttpGet("Brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrand()
    {
        return Ok(await _rep.GetproductBrands());
    }
    [HttpGet("Types")]

    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllproductType()
    {
        return Ok(await _rep.GetProductType());
    }
     
}