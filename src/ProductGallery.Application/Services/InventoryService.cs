using Microsoft.AspNetCore.Http;
using ProductGallery.Application.Interfaces;
using ProductGallery.Domain.Contracts;
using ProductGallery.Domain.Entities;
using ProductGallery.Domain.Exceptions;
using static System.Net.Mime.MediaTypeNames;

namespace ProductGallery.Application.Services;

internal class InventoryService : IInventoryService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IFileStorage<ProductImage> _imageStorage;

    public InventoryService(IRepository<Product> productRepository,
        IRepository<Category> categoryRepository,
        IFileStorage<ProductImage> imageStorage)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _imageStorage = imageStorage ?? throw new ArgumentNullException(nameof(imageStorage));
    }

    public async Task<Product> AddProduct(string name, string description, string categoryId, IFormFile file)
    {
        // buscar caterogia en la base de datos
        var category = await _categoryRepository.GetByIdAsync(Guid.Parse(categoryId));
        // si no existe throw Exception
        if (category is null) throw new ApiException("Category notfound");

        // Crear entidad de nuevo producto
        var product = new Product(name, description);
        product.AddCategory(category);
        // Cargar imagen en blobStorage
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            var image = new ProductImage(file.FileName, file.ContentType, memoryStream.ToArray());
            var imageUrl = await _imageStorage.SaveFileAsync(image);
            // Asignar Url de imagen en el producto
            product.AddImage(imageUrl);
            //product.AddImage($"https://myclean.blob.core.windows.net/productimages/{file.FileName}");
        }

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
