using Microsoft.EntityFrameworkCore;

namespace ProductGallery.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}

