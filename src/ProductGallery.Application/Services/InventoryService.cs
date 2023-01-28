using ProductGallery.Application.Interfaces;
using ProductGallery.Domain.Contracts;
using ProductGallery.Domain.Entities;
using ProductGallery.Domain.Exceptions;

namespace ProductGallery.Application.Services;

internal class InventoryService : IInventoryService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Category> _categoryRepository;

    public InventoryService(IRepository<Product> productRepository,
        IRepository<Category> categoryRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<Product> AddProduct(string name, string description, string categoryId)
    {
        // buscar caterogia en la base de datos
        var category = await _categoryRepository.GetByIdAsync(Guid.Parse(categoryId));
        // si no existe throw Exception
        if (category is null) throw new ApiException("Category notfound");

        // Cargar imagen en blobStorage
        // Crear entidad de nuevo producto
        var product = new Product(name, description);
        product.AddCategory(category);
        // Asignar Url de imagen en el producto
        product.AddImage("https://myclean.blob.core.windows.net/productimages/Trash splash.jpg");

        // Guardar registro en base de datos
        await _productRepository.AddAsync(product);
        return product;
    }

    public Task DeleteProduct(string productId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
