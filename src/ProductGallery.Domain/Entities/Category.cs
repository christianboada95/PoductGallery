using ProductGallery.Domain.Commom;

namespace ProductGallery.Domain.Entities;

public class Category : EntityBase
{
    public string Name { get; set; }

    public virtual ICollection<Product>? Products { get; set; }

    public Category(string name)
    {
        Name = name;
    }
}
