using ProductGallery.Domain.Commom;

namespace ProductGallery.Domain.Entities;

public class Category : EntityBase
{
    public string Name { get; set; }

    public virtual ICollection<Product>? Products { get; set; }

#pragma warning disable CS8618 // Required by Entity Framework
    public Category() { }

    public Category(string name)
    {
        Name = name;
    }
}
