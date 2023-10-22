using System.Text.Json;
using Core.Interface.Generic;
using Core.Interface.IReposetory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopStoreApi.Data.Context;


namespace ShopStoreApi.Controllers;

[ApiController]
[Route("asi/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IGenericRepository<ProductBrand> _productbrand;
    private readonly IGenericRepository<ProductType> _producttype;
    private readonly IGenericRepository<product> _product;

    public ProductController(IGenericRepository<product> product, IGenericRepository<ProductType> producttype,
        IGenericRepository<ProductBrand> productbrand)
    {
        _product = product;
        _producttype = producttype;
        _productbrand = productbrand;
    }

    //get product from database
    [HttpGet]
    public async Task<IReadOnlyList<product>> GetAllProduct()
    {
        var products = await _product.GetAll();

        return products;
    }

// this command  get on product in our application 
    [HttpGet("{id}")]
    public async Task<product> Getproduct(int id)
    {
        try
        {
            var product = await _product.GetById(id);
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
        return Ok(await _productbrand.GetAll());
    }

    [HttpGet("Types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllproductType()
    {
        return Ok(await _producttype.GetAll());
    }
}