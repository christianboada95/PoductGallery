using Microsoft.EntityFrameworkCore;
using ProductGallery.Application.Interfaces;
using ProductGallery.Domain.Entities;
using ProductGallery.Infrastructure.Data;
using ProductGallery.SharedKernel;

namespace ProductGallery.Persistence.Repositories;

internal class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    private readonly AppDbContext _appDbContext;
    public ProductRepository(AppDbContext dbContext)
        : base(dbContext) => _appDbContext = dbContext;

    public Task<List<Product>> PagedListAsync(int skip, int take)
    {
        return _appDbContext.Products.Skip(skip).Take(take).ToListAsync();
    }
}
