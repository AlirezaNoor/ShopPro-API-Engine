using Microsoft.AspNetCore.Mvc;
using ShopStoreApi.Errors;

namespace ShopStoreApi.Controllers;
[Route("errors/{code}")]
    
public class ErrorController:BaseApiController
{
    [HttpGet]
    public ActionResult Errorhandle(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}