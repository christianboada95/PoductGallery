﻿using ProductGallery.Domain.Commom;

namespace ProductGallery.Domain.Entities;

public class Product : EntityBase
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }

    public virtual Category? Category { get; set; }

    public Product(string name) => Name = name;

    public Product(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void AddCategory(string categoryId)
    {
        CategoryId = Guid.Parse(categoryId);
    }

    public void AddImage(string imageUrl)
    {
        Image = imageUrl;
    }
}
