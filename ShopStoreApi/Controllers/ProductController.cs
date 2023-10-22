using System.Text.Json;
using Core.Interface.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopStoreApi.Data.Context;


namespace ShopStoreApi.Controllers;

public class ProductController : BaseApiController
{
    private readonly IUnitOfWork _context;

    public ProductController(IUnitOfWork context)
    {
        _context = context;
    }

    //get product from database
    [HttpGet]
    public async Task<IReadOnlyList<product>> GetAllProduct()
    {
        var products = _context.productuw.get(null, "productbrand,producttype").ToList();

        return products;
    }

// this command  get on product in our application 
    [HttpGet("{id}")]
    public async Task<product> Getproduct(int id)
    {
        return _context.productuw.Getbyid(id);
    }

    [HttpGet("Brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrand()
    {
        return _context.productbranduw.get().ToList();
    }

    [HttpGet("Types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllproductType()
    {
        return _context.producttypeuw.get().ToList();
    }
}