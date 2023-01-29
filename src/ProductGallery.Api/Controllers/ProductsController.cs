using Microsoft.AspNetCore.Mvc;
using ProductGallery.Application.DataTransferObjects.Requests;
using ProductGallery.Application.DataTransferObjects.Responses;
using ProductGallery.Application.Interfaces;
using ProductGallery.Domain.Contracts;
using ProductGallery.Domain.Entities;

namespace ProductGallery.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IRepository<Product> _repository;
    private readonly IInventoryService _inventoryService;

    public ProductsController(ILogger<ProductsController> logger,
        IRepository<Product> repository,
        IInventoryService inventoryService)
    {
        _logger = logger;
        _repository = repository;
        _inventoryService = inventoryService;
    }

    [HttpPost(Name = "CreateProduct")]
    public async Task<ActionResult<CreateProductResponse>> Post([FromForm] CreateProductRequest request)
    {
        if (request.Name == null)
        {
            return BadRequest();
        }

        //var newProduct = new Product(request.Name, request.Description);
        //var createdItem = await _repository.AddAsync(newProduct);
        var createdItem = await _inventoryService.AddProduct(request.Name, request.Description, request.Category, request.Image);
        var response = new CreateProductResponse
        (
          id: createdItem.Id.ToString(),
          name: createdItem.Name
        );

        return Ok(response);
    }

    [HttpGet(Name = "GetProducts")]
    public async Task<IActionResult> Get()
    {
        var products = await _repository.ListAsync();
        var response = new ProductListResponse()
        {
            Products = products.Select(x =>
                new ProductRecord(x.Id.ToString(), x.Name, x.Description)).ToList()
        };

        return Ok(response);
    }
}