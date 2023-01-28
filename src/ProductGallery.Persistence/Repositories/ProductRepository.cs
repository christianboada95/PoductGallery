using ProductGallery.Domain.Entities;
using ProductGallery.Infrastructure.Data;
using ProductGallery.SharedKernel;

namespace ProductGallery.Persistence.Repositories;

internal class ProductRepository : RepositoryBase<Product>
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext dbContext)
        : base(dbContext) => _appDbContext = dbContext;
}
