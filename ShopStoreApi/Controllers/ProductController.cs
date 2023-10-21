using Microsoft.AspNetCore.Mvc;

namespace ShopStoreApi.Controllers;

[ApiController]
[Route("asi/[controller]")]
public class ProductController : ControllerBase
{

    public IActionResult GetAllProduct()
    {
        return Ok();
    }
    
}