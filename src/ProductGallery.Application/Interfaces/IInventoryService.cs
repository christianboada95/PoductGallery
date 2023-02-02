using ProductGallery.Application.Filters;
using ProductGallery.Domain.Entities;

namespace ProductGallery.Application.Interfaces;

public interface IInventoryService
{
    Task<Product> GetProduct(Guid productId);
    Task<List<Product>> GetProducts(QueryFilter queryFilter, string orderByQueryString);
    Task<Product> AddProduct(string name, string description, Guid categoryId, ProductImage image);
    Task<Product> UpdateProduct(Guid productId, string name, string description, Guid categoryId, ProductImage image);
    Task DeleteProduct(Guid productId);
}
