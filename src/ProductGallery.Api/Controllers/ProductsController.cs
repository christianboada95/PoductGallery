using Microsoft.AspNetCore.Mvc;

namespace ProductGallery.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public async Task<IActionResult> Get()
    {
        return Ok("Product List");
    }
}