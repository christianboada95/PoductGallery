using Microsoft.AspNetCore.Http;
using ProductGallery.Domain.Entities;

namespace ProductGallery.Application.Interfaces;

public interface IInventoryService
{
    Task<List<Product>> GetProducts();
    Task<Product> AddProduct(string name, string description, string categoryId, IFormFile file);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(string productId);
}
