using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductGallery.Application.DataTransferObjects.Requests;
using ProductGallery.Application.DataTransferObjects.Responses;
using ProductGallery.Application.Filters;
using ProductGallery.Application.Interfaces;
using ProductGallery.Domain.Entities;

namespace ProductGallery.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IInventoryService _inventoryService;

    public ProductsController(ILogger<ProductsController> logger,
        IMapper mapper,
        IProductRepository inventoryRepository,
        IInventoryService inventoryService)
    {
        _logger = logger;
        _mapper = mapper;
        _productRepository = inventoryRepository;
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
        var productImage = _mapper.Map<ProductImage>(request.Image);
        var createdItem = await _inventoryService.AddProduct(request.Name, request.Description, request.CategoryId, productImage);
        var response = new CreateProductResponse
        (
          id: createdItem.Id.ToString(),
          name: createdItem.Name
        );

        return Ok(response);
    }

    [HttpPut("{productId}")]
    public async Task<ActionResult<Product>> Put([FromRoute] Guid productId, [FromForm] UpdateProductRequest request)
    {
        var productImage = _mapper.Map<ProductImage>(request.Image);
        var product = await _inventoryService.UpdateProduct(productId,
            request.Name, request.Description, request.CategoryId, productImage);

        return Ok(product);
    }

    [HttpDelete("{productId:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid productId)
    {
        await _inventoryService.DeleteProduct(productId);
        return Ok("Product Deleted successfull");
    }

    [HttpGet(Name = "GetProducts")]
    public async Task<IActionResult> Get([FromQuery] ListPagedProductRequest request)
    {
        QueryFilter filter = new(request.PageIndex, request.PageSize, input: request.FindBy);
        var products = await _inventoryService.GetProducts(filter, request.OrderBy);
        var totalRecords = await _productRepository.GetTotalProducts();
        var response = new ProductListResponse(
            products.Select(x =>
                new ProductRecord(x.Id.ToString(), x.Name, x.Description,
                    new CategoryRecord(x.Category.Id.ToString(), x.Category.Name, x.Category.CreatedAt, x.Category.UpdateAt),
                    x.ImageUrl, x.CreatedAt, x.UpdateAt)).ToList(),
            filter.PageIndex, filter.PageSize, totalRecords
        );

        return Ok(response);
    }
}

