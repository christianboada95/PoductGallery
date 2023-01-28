using ProductGallery.Application.Interfaces;
using ProductGallery.Domain.Contracts;
using ProductGallery.Domain.Entities;

namespace ProductGallery.Application.Services;

internal class InventoryService : IInventoryService
{
    private readonly IRepository<Product> _repository;

    public InventoryService(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Product> AddProduct(string name, string description)
    {
        // buscar caterogia en la base de datos
        // si no existe throw Exception

        // Cargar imagen en blobStorage
        // Crear entidad de nuevo producto
        var product = new Product(name, description);
        // Asignar Url de imagen en el producto
        product.AddImage("https://myclean.blob.core.windows.net/productimages/Trash splash.jpg");

        // Guardar registro en base de datos 
        await _repository.AddAsync(product);
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
