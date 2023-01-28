using System;
using Microsoft.EntityFrameworkCore;
using ProductGallery.Domain.Contracts;
using ProductGallery.Domain.Entities;
using ProductGallery.Infrastructure.Data;
using ProductGallery.SharedKernel;

namespace ProductGallery.Persistence.Repositories;

public class CategoryRepository : RepositoryBase<Category>
{
    private readonly AppDbContext _appDbContext;

    public CategoryRepository(AppDbContext dbContext)
        : base(dbContext) => _appDbContext = dbContext;
}

