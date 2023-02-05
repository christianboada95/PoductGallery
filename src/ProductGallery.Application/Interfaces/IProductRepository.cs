using ProductGallery.Domain.Contracts;
using ProductGallery.Domain.Entities;

namespace ProductGallery.Application.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> PagedListAsync(int skip, int take);
    Task<int> GetTotalProducts();
}
