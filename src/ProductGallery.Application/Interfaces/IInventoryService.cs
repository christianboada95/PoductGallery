using ProductGallery.Domain.Entities;

namespace ProductGallery.Application.Interfaces;

public interface IInventoryService
{
    Task<List<Product>> GetProducts();
    Task<Product> AddProduct(string name, string description, string categoryId);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(string productId);
}
