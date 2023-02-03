using ProductGallery.Application.Filters;
using ProductGallery.Application.Interfaces;
using ProductGallery.Application.Specifications;
using ProductGallery.Application.Utilities;
using ProductGallery.Domain.Contracts;
using ProductGallery.Domain.Entities;
using ProductGallery.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace ProductGallery.Application.Services;

internal class InventoryService : IInventoryService
{
    private readonly IProductRepository _productRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IFileStorage<ProductImage> _imageStorage;

    public InventoryService(IProductRepository productRepository,
        IRepository<Category> categoryRepository,
        IFileStorage<ProductImage> imageStorage)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _imageStorage = imageStorage ?? throw new ArgumentNullException(nameof(imageStorage));
    }

    public async Task<Product> AddProduct(string name, string description, Guid categoryId, ProductImage image)
    {
        // buscar caterogia en la base de datos
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null) throw new ApiException("Category Not found");

        var product = new Product(name, description);
        product.AddCategory(category);

        var imageUrl = await _imageStorage.SaveFileAsync(image);
        product.AddImage(imageUrl);

        await _productRepository.AddAsync(product);
        return product;
    }

    public async Task DeleteProduct(Guid productId)
    {
        var product = await GetProduct(productId);
        await _productRepository.DeleteAsync(product);
    }

    public async Task<Product> GetProduct(Guid productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product is null) throw new ApiException("Product Not Found");
        return product;
    }

    public async Task<List<Product>> GetProducts(QueryFilter filter, string orderByQueryString)
    {
        // Filtro
        var spec = new ProductFilterPaginatedSpecification(
            skip: (filter.PageIndex - 1) * filter.PageSize,
            take: filter.PageSize,
            input: filter.FindBy);

        var products = await _productRepository.ListAsync(spec);

        // Orden
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return products.OrderBy(x => x.Name).ToList();

        return products.AsQueryable().ApplySort(orderByQueryString).ToList();
    }

    public async Task<Product> UpdateProduct(Guid productId, string name, string description, Guid categoryId, ProductImage image)
    {
        var product = await GetProduct(productId);
        product.Name = name;
        product.Description = description;

        var imageUrl = await _imageStorage.SaveFileAsync(image);
        product.AddImage(imageUrl);

        await _productRepository.UpdateAsync(product);
        return product;
    }
}
